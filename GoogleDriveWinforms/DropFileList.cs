using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleDriveWinforms
{
    public partial class DropFileList : UserControl
    {
        public List<string> Files
        { get=> fileList.Items.Cast<string>().ToList();
        }
        public DropFileList()
        {
            InitializeComponent();
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {

            var files = (string[]?)e.Data?.GetData(DataFormats.FileDrop, false);
            if(files!=null)
            {
                foreach(var file in files)
                {
                    fileList.Items.Add(file);
                }
            }
            fileList.BackColor = Color.White;
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
                fileList.BackColor = Color.Cyan;
            }
            
        }

        private void fileList_DragLeave(object sender, EventArgs e)
        {
            fileList.BackColor = Color.White;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var selectedFiles = fileList.SelectedItems;
            while(selectedFiles.Count!=0)
            {
                fileList.Items.Remove(selectedFiles[0]);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.RestoreDirectory = false;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var files = dialog.FileNames;
                foreach(var file in files)
                {
                    fileList.Items.Add(file);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear();
        }
    }
}
