using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DosTerrainImporter
{
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
        }

        private void MainGrayScaleButton_Click(object sender, EventArgs e)
        {
            Panel targetPanel = ((this.Parent) as Panel);
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(new GrayScaleUserControl());
        }

        private void MainL3dtButton_Click(object sender, EventArgs e)
        {
            Panel targetPanel = ((this.Parent) as Panel);
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(new L3dtUserControl());
        }
    }
}
