using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DosTerrainImporter.Importer;

namespace DosTerrainImporter
{
    public partial class L3dtUserControl : UserControl
    {
        Microsoft.Win32.OpenFileDialog l3dtDosBrowseDialog = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.OpenFileDialog l3dtFileBrowseDialog = new Microsoft.Win32.OpenFileDialog();

        public L3dtUserControl()
        {
            InitializeComponent();
            l3dtDosBrowseDialog.Filter = "Data files|*.data";
            l3dtFileBrowseDialog.Filter = "L3DT files|*.proj";
        }

        private void L3dtGenerate_Click(object sender, EventArgs e)
        {
            float minHeight;
            float maxHeight;
            string dosFileName = l3dtDosTextBox.Text;
            string l3dtFileName = l3dtTextBox.Text;

            if (!File.Exists(dosFileName))
            {
                MessageBox.Show("Error: The terrain file doesn't exist.");
                return;
            }

            if (!File.Exists(l3dtFileName))
            {
                MessageBox.Show("Error: The heightmap file doesn't exist.");
                return;
            }
            if (!float.TryParse(l3dtMinHeightTextBox.Text, out minHeight))
            {
                MessageBox.Show("Error: Black pixel height should be a number.");
                return;
            }
            if (!float.TryParse(l3dtMaxHeightTextBox.Text, out maxHeight))
            {
                MessageBox.Show("Error: White pixel height should be a number.");
                return;
            }

            try
            {
                SetControlsStatus(false);

                L3dtImporter importer = new L3dtImporter(dosFileName, l3dtFileName, minHeight, maxHeight, true);
                this.L3dtProgressBar.Maximum = importer.getMaximumWriteOperations();
                this.L3dtProgressBar.Step = 1;
                this.L3dtProgressBar.Value = 0;

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += importer.execute;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerCompleted += worker_Completed;
                worker.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                SetControlsStatus(true);
            }
        }

        private void SetControlsStatus(bool status)
        {
            this.L3dtDosBrowse.Enabled = status;
            this.L3dtFileBrowse.Enabled = status;
            this.L3dtGenerate.Enabled = status;
            this.L3dtCancelButton.Enabled = status;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.L3dtProgressBar.Value = e.ProgressPercentage;
        }
        
        void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.L3dtProgressBar.Value = this.L3dtProgressBar.Maximum;
        }

        private void L3dtDosBrowse_Click(object sender, EventArgs e)
        {
            Nullable<bool> result = l3dtDosBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = l3dtDosBrowseDialog.FileName;
                l3dtDosTextBox.Text = filename;
            }
        }

        private void L3dtFileBrowse_Click(object sender, EventArgs e)
        {
            Nullable<bool> result = l3dtFileBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = l3dtFileBrowseDialog.FileName;
                l3dtTextBox.Text = filename;
            }
        }

        private void L3dtCancelButton_Click(object sender, EventArgs e)
        {
            Panel targetPanel = ((this.Parent) as Panel);
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(new MainControl());
        }
    }
}
