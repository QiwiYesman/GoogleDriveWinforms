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
    public partial class FileInfoPanel : UserControl
    {
        double _size = 0;
        public FileInfoPanel()
        {
            InitializeComponent();
        }

        public double FileSize
        {
            get => _size;
            set{
                _size = Math.Round(value, 2);
                fileSizeText.Text = $"{_size} KB   or   " +
                    $"{Math.Round(_size / 1024, 2)} MB";
            }
        }
    }
}
