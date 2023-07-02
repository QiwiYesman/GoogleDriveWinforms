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
    public partial class NamedProgressBar : UserControl
    {
        public event Action<NamedProgressBar>? Finished;
        public override string Text { 
            get => textLabel.Text;
            set => textLabel.Text = value;
        }

        public NamedProgressBar()
        {
            InitializeComponent();
        }

        public void Progress(double value)
        {
            progressBar1.Invoke(() =>
            {
                if (value == -1)
                {
                    progressBar1.BackColor = Color.Red;
                    Finished?.Invoke(this);
                    return;
                }
                progressBar1.Value = (int)value;
                if ((int)value == 100)
                {
                    Finished?.Invoke(this);
                }
            });
        }
    }
}
