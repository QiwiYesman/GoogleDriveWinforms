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
    public partial class AutoProgressPanel : UserControl
    {
        public List<NamedProgressBar> Bars { get; set; }
        public AutoProgressPanel()
        {
            InitializeComponent();
            Bars = new();
        }
        
        void PlaceBar(NamedProgressBar bar)
        {
            panel.Controls.Add(bar);
        }

        public Action<double> NewBar(string name)
        {
            var bar = new NamedProgressBar() { Text = name };
            bar.Finished += Remove;

            Bars.Add(bar);
            panel.Invoke(() =>{
                panel.Controls.Add(bar);
                bar.Show();
                bar.Dock = DockStyle.Top;
            });
         
            return bar.Progress;

        }

        public void Remove(NamedProgressBar bar)
        {
            Bars.Remove(bar);
            panel.Controls.Remove(bar);
        }

    }
}
