using DosTerrainImporter.Importer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DosTerrainImporter
{
    /// <summary>
    /// Interaction logic for ProcessWindow.xaml
    /// </summary>
    public partial class ProcessWindow : Window
    {
        private TerrainImporter importer;

        public ProcessWindow(TerrainImporter importer)
        {
            InitializeComponent();
            this.importer = importer;
            statusBar.Maximum = this.importer.getMaximumWriteOperations();
            statusBar.Minimum = 0;            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (this.importer != null)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += this.importer.execute;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerCompleted += worker_Completed;
                worker.RunWorkerAsync();
            }
            else
            {
                throw new Exception("Importer can't be null");
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusBar.Value = e.ProgressPercentage;           
        }

        void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            statusBar.Value = statusBar.Maximum;
            this.Close();
        }
    }
}
