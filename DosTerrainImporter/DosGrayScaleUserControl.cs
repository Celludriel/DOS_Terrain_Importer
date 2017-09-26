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
    public partial class DosGrayScaleUserControl : UserControl
    {
        Microsoft.Win32.OpenFileDialog grayDosBrowseDialog = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.OpenFileDialog grayFileBrowseDialog = new Microsoft.Win32.OpenFileDialog();

        public DosGrayScaleUserControl()
        {
            InitializeComponent();
            grayDosBrowseDialog.Filter = "Data files|*.data";
            grayFileBrowseDialog.Filter = "Bitmap files|*.bmp;*.jpg;*.jpeg;*.png";
        }

        private void SetControlsStatus(bool status)
        {
            this.GrayDosBrowse.Enabled = status;
            this.GrayBitmapBrowse.Enabled = status;
            this.GrayGenerate.Enabled = status;
            this.GrayCancelButton.Enabled = status;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.GrayProgressBar.Value = e.ProgressPercentage;
        }

        void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrayProgressBar.Value = this.GrayProgressBar.Maximum;
        }

        private void GrayGenerate_Click(object sender, EventArgs e)
        {
            float minHeight;
            float maxHeight;
            string dosFileName = grayDosTextBox.Text;
            string grayScaleFileName = grayBitmapTextBox.Text;

            if (!File.Exists(grayDosTextBox.Text))
            {
                MessageBox.Show("Error: The terrain file doesn't exist.");
                return;
            }
            if (!File.Exists(grayBitmapTextBox.Text))
            {
                MessageBox.Show("Error: The heightmap file doesn't exist.");
                return;
            }
            if (!float.TryParse(grayMinHeightTextBox.Text, out minHeight))
            {
                MessageBox.Show("Error: Black pixel height should be a number.");
                return;
            }
            if (!float.TryParse(grayMaxHeightTextBox.Text, out maxHeight))
            {
                MessageBox.Show("Error: White pixel height should be a number.");
                return;
            }

            try
            {
                SetControlsStatus(false);

                DosGrayScaleImporter importer = new DosGrayScaleImporter(dosFileName, grayScaleFileName, minHeight, maxHeight);
                this.GrayProgressBar.Maximum = importer.getMaximumWriteOperations();
                this.GrayProgressBar.Step = 1;
                this.GrayProgressBar.Value = 0;

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

        private void GrayDosBrowse_Click(object sender, EventArgs e)
        {
            Nullable<bool> result = grayDosBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = grayDosBrowseDialog.FileName;
                grayDosTextBox.Text = filename;
            }
        }

        private void GrayBitmapBrowse_Click(object sender, EventArgs e)
        {
            Nullable<bool> result = grayFileBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = grayFileBrowseDialog.FileName;
                grayBitmapTextBox.Text = filename;
            }
        }

        private void GrayCancelButton_Click(object sender, EventArgs e)
        {
            Panel targetPanel = ((this.Parent) as Panel);
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(new DosControl());
        }
    }
}
