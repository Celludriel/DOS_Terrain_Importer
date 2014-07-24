using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DosTerrainImporter.Model;
using DosTerrainImporter.Importer;

namespace DosTerrainImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog l3dtDosBrowseDialog = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.OpenFileDialog l3dtFileBrowseDialog = new Microsoft.Win32.OpenFileDialog();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void L3dtGenerate_Click(object sender, RoutedEventArgs e)
        {
            float minHeight;
            float maxHeight;
            string dosFileName = dosTextBox.Text;
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
            if (!float.TryParse(minHeightTextBox.Text, out minHeight))
            {
                MessageBox.Show("Error: Black pixel height should be a number.");
                return;
            }
            if (!float.TryParse(maxHeightTextBox.Text, out maxHeight))
            {
                MessageBox.Show("Error: White pixel height should be a number.");
                return;
            }

            try
            {
                L3dtImporter importer = new L3dtImporter();
                importer.importL3dt(dosFileName, l3dtFileName, minHeight, maxHeight);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void L3dtDosBrowse_Click(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = l3dtDosBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = l3dtDosBrowseDialog.FileName;
                dosTextBox.Text = filename;
            }
        }

        private void L3dtFileBrowse_Click(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = l3dtFileBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = l3dtFileBrowseDialog.FileName;
                l3dtTextBox.Text = filename;
            }
        }

        private void L3dtDosTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                dosTextBox.Text = fileNames[0];
            }
        }

        private void L3dtDosTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void L3dtTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                l3dtTextBox.Text = fileNames[0];
            }
        }

        private void L3dtTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

    }
}