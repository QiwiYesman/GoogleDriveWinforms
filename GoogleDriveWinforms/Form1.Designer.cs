namespace GoogleDriveWinforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView = new System.Windows.Forms.TreeView();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.connectButton = new System.Windows.Forms.Button();
            this.loadTreeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bar = new GoogleDriveWinforms.AutoProgressPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.urlButton = new System.Windows.Forms.Button();
            this.urlText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.savePathText = new System.Windows.Forms.TextBox();
            this.saveBrowseButton = new System.Windows.Forms.Button();
            this.folderNameText = new System.Windows.Forms.TextBox();
            this.createFolderButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            this.removeUserButton = new System.Windows.Forms.Button();
            this.userCombo = new System.Windows.Forms.ComboBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.folderSizeButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.dropFileList = new GoogleDriveWinforms.DropFileList();
            this.fileInfoPanel = new GoogleDriveWinforms.FileInfoPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fileSystemWatcher3 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher3)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.FullRowSelect = true;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(265, 499);
            this.treeView.TabIndex = 0;
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // connectButton
            // 
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Location = new System.Drawing.Point(3, 0);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // loadTreeButton
            // 
            this.loadTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadTreeButton.Location = new System.Drawing.Point(3, 59);
            this.loadTreeButton.Name = "loadTreeButton";
            this.loadTreeButton.Size = new System.Drawing.Size(75, 23);
            this.loadTreeButton.TabIndex = 2;
            this.loadTreeButton.Text = "Load tree";
            this.loadTreeButton.UseVisualStyleBackColor = true;
            this.loadTreeButton.Click += new System.EventHandler(this.loadTreeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dropFileList);
            this.panel1.Controls.Add(this.fileInfoPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 499);
            this.panel1.TabIndex = 4;
            // 
            // bar
            // 
            this.bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bar.BackColor = System.Drawing.Color.Transparent;
            this.bar.Location = new System.Drawing.Point(6, 172);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(240, 126);
            this.bar.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.urlButton);
            this.panel3.Controls.Add(this.urlText);
            this.panel3.Controls.Add(this.saveButton);
            this.panel3.Controls.Add(this.savePathText);
            this.panel3.Controls.Add(this.saveBrowseButton);
            this.panel3.Controls.Add(this.folderNameText);
            this.panel3.Controls.Add(this.createFolderButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 304);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 114);
            this.panel3.TabIndex = 14;
            // 
            // urlButton
            // 
            this.urlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.urlButton.Location = new System.Drawing.Point(3, 22);
            this.urlButton.Name = "urlButton";
            this.urlButton.Size = new System.Drawing.Size(90, 23);
            this.urlButton.TabIndex = 14;
            this.urlButton.Text = "Url";
            this.urlButton.UseVisualStyleBackColor = true;
            this.urlButton.Click += new System.EventHandler(this.urlButton_ClickAsync);
            // 
            // urlText
            // 
            this.urlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlText.Location = new System.Drawing.Point(99, 22);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(300, 23);
            this.urlText.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(3, 51);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // savePathText
            // 
            this.savePathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.savePathText.Location = new System.Drawing.Point(99, 51);
            this.savePathText.Name = "savePathText";
            this.savePathText.Size = new System.Drawing.Size(300, 23);
            this.savePathText.TabIndex = 7;
            // 
            // saveBrowseButton
            // 
            this.saveBrowseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.saveBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBrowseButton.Location = new System.Drawing.Point(405, 51);
            this.saveBrowseButton.Name = "saveBrowseButton";
            this.saveBrowseButton.Size = new System.Drawing.Size(26, 23);
            this.saveBrowseButton.TabIndex = 12;
            this.saveBrowseButton.Text = "...";
            this.saveBrowseButton.UseVisualStyleBackColor = true;
            this.saveBrowseButton.Click += new System.EventHandler(this.saveBrowseButton_Click);
            // 
            // folderNameText
            // 
            this.folderNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderNameText.Location = new System.Drawing.Point(99, 80);
            this.folderNameText.Name = "folderNameText";
            this.folderNameText.Size = new System.Drawing.Size(300, 23);
            this.folderNameText.TabIndex = 9;
            // 
            // createFolderButton
            // 
            this.createFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createFolderButton.Location = new System.Drawing.Point(3, 81);
            this.createFolderButton.Name = "createFolderButton";
            this.createFolderButton.Size = new System.Drawing.Size(89, 23);
            this.createFolderButton.TabIndex = 6;
            this.createFolderButton.Text = "Create folder";
            this.createFolderButton.UseVisualStyleBackColor = true;
            this.createFolderButton.Click += new System.EventHandler(this.createFolderButton_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.exportButton);
            this.panel2.Controls.Add(this.removeUserButton);
            this.panel2.Controls.Add(this.userCombo);
            this.panel2.Controls.Add(this.loadTreeButton);
            this.panel2.Controls.Add(this.connectButton);
            this.panel2.Controls.Add(this.removeButton);
            this.panel2.Controls.Add(this.folderSizeButton);
            this.panel2.Controls.Add(this.uploadButton);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 147);
            this.panel2.TabIndex = 13;
            // 
            // exportButton
            // 
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Location = new System.Drawing.Point(84, 88);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 14;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // removeUserButton
            // 
            this.removeUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeUserButton.Location = new System.Drawing.Point(152, 30);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(88, 23);
            this.removeUserButton.TabIndex = 13;
            this.removeUserButton.Text = "Remove user";
            this.removeUserButton.UseVisualStyleBackColor = true;
            // 
            // userCombo
            // 
            this.userCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userCombo.FormattingEnabled = true;
            this.userCombo.Location = new System.Drawing.Point(84, 1);
            this.userCombo.Name = "userCombo";
            this.userCombo.Size = new System.Drawing.Size(156, 23);
            this.userCombo.TabIndex = 12;
            // 
            // removeButton
            // 
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Location = new System.Drawing.Point(165, 59);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // folderSizeButton
            // 
            this.folderSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.folderSizeButton.Location = new System.Drawing.Point(0, 121);
            this.folderSizeButton.Name = "folderSizeButton";
            this.folderSizeButton.Size = new System.Drawing.Size(156, 23);
            this.folderSizeButton.TabIndex = 4;
            this.folderSizeButton.Text = "Folder size calculate";
            this.folderSizeButton.UseVisualStyleBackColor = true;
            this.folderSizeButton.Click += new System.EventHandler(this.folderSizeButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Location = new System.Drawing.Point(84, 59);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 10;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // dropFileList
            // 
            this.dropFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropFileList.Location = new System.Drawing.Point(252, 3);
            this.dropFileList.Name = "dropFileList";
            this.dropFileList.Size = new System.Drawing.Size(179, 295);
            this.dropFileList.TabIndex = 11;
            // 
            // fileInfoPanel
            // 
            this.fileInfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileInfoPanel.FileSize = 0D;
            this.fileInfoPanel.Location = new System.Drawing.Point(0, 418);
            this.fileInfoPanel.Name = "fileInfoPanel";
            this.fileInfoPanel.Size = new System.Drawing.Size(443, 81);
            this.fileInfoPanel.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(712, 499);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 3;
            // 
            // fileSystemWatcher3
            // 
            this.fileSystemWatcher3.EnableRaisingEvents = true;
            this.fileSystemWatcher3.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 499);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView treeView;
        private FileSystemWatcher fileSystemWatcher1;
        private FileSystemWatcher fileSystemWatcher2;
        private Button connectButton;
        private Button loadTreeButton;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private FileSystemWatcher fileSystemWatcher3;
        private FileInfoPanel fileInfoPanel;
        private Button folderSizeButton;
        private TextBox savePathText;
        private Button createFolderButton;
        private Button removeButton;
        private Button uploadButton;
        private TextBox folderNameText;
        private Button saveButton;
        private DropFileList dropFileList;
        private Button saveBrowseButton;
        private Panel panel3;
        private Panel panel2;
        private AutoProgressPanel bar;
        private Button removeUserButton;
        private ComboBox userCombo;
        private Button exportButton;
        private Button urlButton;
        private TextBox urlText;
    }
}