using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveWinforms
{
    using DriveFile = Google.Apis.Drive.v3.Data.File;
    public class FileInfo : TreeNode
    {
        public DriveFile File { get; set; }
        public string ParentId { get; set; }
        public FileInfo(DriveFile file, string parentId)
        {
            File = file;
            Text = File.Name;
            ParentId = parentId;
        }

    }
}
