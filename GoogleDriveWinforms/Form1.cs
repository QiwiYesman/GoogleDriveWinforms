using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Xml.Linq;

namespace GoogleDriveWinforms
{
    public partial class Form1 : Form
    {
        public FileInfo? SelectedFile { get; set; }
        GoogleDriveRequests drive;
        public Form1()
        {
            InitializeComponent();
            drive = new();
            treeView.Nodes.Add(new FileInfo(new()
            {
                Name = "root",
                MimeType = "application/vnd.google-apps.folder",
                Id="root",
                Parents = new string[] { "" },
            }, "")
            { Name="rootNode"});;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string userName = userCombo.Text;
            drive.Login(userName);
        }

        private void loadTreeButton_Click(object sender, EventArgs e)
        {
            drive.LoadTree("root", treeView.Nodes["rootNode"]);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var currentNode = treeView.SelectedNode as FileInfo;
            if (currentNode == null) return;
            SelectedFile = currentNode;
            fileInfoPanel.fileNameText.Text = SelectedFile.File.Name;
            fileInfoPanel.fileTypeText.Text = SelectedFile.File.MimeType;
            fileInfoPanel.FileSize = SelectedFile.File.Size/1024 ?? 0;
        }

        void CalculateFolderSize(FileInfo node, ref double size)
        {
            foreach(FileInfo childNode in node.Nodes)
            {
                double fileSize = Convert.ToDouble(childNode.File.Size);
                if (fileSize == 0)
                {
                    CalculateFolderSize(childNode, ref size);
                }
                else
                {
                    size += fileSize/1024;
                }
            }
        }
        private void folderSizeButton_Click(object sender, EventArgs e)
        {
            var file = treeView.SelectedNode as FileInfo;
            if(file !=null)
            {
                double size = 0.0;
                CalculateFolderSize(file, ref size);
                fileInfoPanel.FileSize = size;
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (SelectedFile == null) return;
            if (!GoogleDriveRequests.isFolder(SelectedFile.File.MimeType)) return;
            var files = dropFileList.Files;
            if (files.Count == 0) return;
            foreach (var file in files)
            {
                var uploaded = drive.Upload(file, SelectedFile.File.Id);
                if (uploaded == null) continue;
                SelectedFile.Nodes.Add(uploaded.Name);
            }
            MessageBox.Show("Loaded");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedFile == null) return;
            if (GoogleDriveRequests.isShortcut(SelectedFile.File.MimeType))
            {
                drive.RemoveFile(SelectedFile.File.ShortcutDetails.TargetId);
            }
            drive.RemoveFile(SelectedFile.File.Id);
            treeView.Nodes.Remove(SelectedFile);
   
        }

        private void saveBrowseButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                savePathText.Text = dialog.SelectedPath;
            }

        }


        public void SaveFolder(FileInfo node, string path)
        {
            List<FileInfo> result = new();
            foreach (FileInfo child in node.Nodes)
            {
                result.Add(child);
            }
            result.AsParallel().ForAll(file => SaveFile(file, path));
            
        }

        public void SaveFile(FileInfo node, string path)
        {
            string id = node.File.Id;
            var stringPath = Path.Combine(path,
    GoogleDriveRequests.CorrectFileName(node.File.Name));

            if (GoogleDriveRequests.isShortcut(node.File.MimeType))
            {
                id = node.File.ShortcutDetails.TargetId;
            }
            else if (GoogleDriveRequests.isFolder(node.File.MimeType))
            {
                if(!Directory.Exists(stringPath))
                {
                    Directory.CreateDirectory(stringPath);
                }
                SaveFolder(node, stringPath);
                return;
            }            
            var m = drive.DownloadFile(id, bar.NewBar(node.File.Name));
            GoogleDriveRequests.Save(m, stringPath);
        }

        public void ExportFile(FileInfo node, string path)
        {
            string id = node.File.Id;
            var stringPath = Path.Combine(path,
    GoogleDriveRequests.CorrectFileName(node.File.Name));
            if (GoogleDriveRequests.isFolder(node.File.MimeType)) return;
            if (GoogleDriveRequests.isShortcut(node.File.MimeType))
            {
                id = node.File.ShortcutDetails.TargetId;
            }
            var m = drive.ExportFile(id, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", bar.NewBar(node.File.Name));;
            GoogleDriveRequests.Save(m, stringPath);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SelectedFile == null) return;
            Task.Run(()=> { 
                SaveFile(SelectedFile, savePathText.Text);
                MessageBox.Show("Saved all");
            });
        }

        private void createFolderButton_Click(object sender, EventArgs e)
        {
            if (SelectedFile == null || !GoogleDriveRequests.isFolder(SelectedFile.File.MimeType)) return;
            string name = GoogleDriveRequests.CorrectFileName(folderNameText.Text);
            if (name == "") return;
            var file = drive.CreateFolder(name, SelectedFile.File.Id);
            if (file == null) return;
            SelectedFile.Nodes.Add(new FileInfo(file, SelectedFile.File.Id));
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);

        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));
            FileInfo? targetNode = treeView.GetNodeAt(targetPoint) as FileInfo;
            if (targetNode == null || !GoogleDriveRequests.isFolder(targetNode.File.MimeType)) return;
            FileInfo? draggedNode = (FileInfo?)e.Data?.GetData(typeof(FileInfo));
            if (draggedNode == null) return;
            if (!draggedNode.Equals(targetNode))
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                    targetNode.Expand();
                    drive.Move(draggedNode.File.Id, targetNode.File.Id, draggedNode.ParentId);
                    draggedNode.ParentId = targetNode.File.Id;
                }
                
            }
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        removeButton.PerformClick();
                        break;
                    }
                case Keys.S:
                    {
                        saveButton.PerformClick();
                        break;
                    }
            }

        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (SelectedFile == null) return;
            Task.Run(() => {
                ExportFile(SelectedFile, savePathText.Text);
                MessageBox.Show("Saved all");
            });
        }

        private async void urlButton_ClickAsync(object sender, EventArgs e)
        {
            if (SelectedFile == null) return;
            string url = urlText.Text;
            var s = await drive.GetUrlStream(url);
            if (s == null)
            {
                MessageBox.Show("Incorrect url");
                return;
            }
            var uploaded = drive.Upload(s, "testy", SelectedFile.File.Id);
            if (uploaded == null) return;
            SelectedFile.Nodes.Add(uploaded.Name);
        }
    }
}