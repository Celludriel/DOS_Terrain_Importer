using System.Windows.Forms;

namespace DosTerrainImporter
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MainPanel.Controls.Add(new GameSelector());
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
