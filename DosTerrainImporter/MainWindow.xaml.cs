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
        Microsoft.Win32.OpenFileDialog grayDosBrowseDialog = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.OpenFileDialog grayFileBrowseDialog = new Microsoft.Win32.OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void L3dtGenerate_Click(object sender, RoutedEventArgs e)
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
                L3dtImporter importer = new L3dtImporter(dosFileName, l3dtFileName, minHeight, maxHeight);
                ProcessWindow processWindow = new ProcessWindow(importer);
                processWindow.Owner = this;
                processWindow.ShowDialog();
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
                l3dtDosTextBox.Text = filename;
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
                l3dtDosTextBox.Text = fileNames[0];
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

        private void GrayGenerate_Click(object sender, RoutedEventArgs e)
        {
            float minHeight;
            float maxHeight;
            string dosFileName = grayDosTextBox.Text;
            string l3dtFileName = grayBitmapTextBox.Text;

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
                GrayScaleImporter importer = new GrayScaleImporter(dosFileName, l3dtFileName, minHeight, maxHeight);
                ProcessWindow processWindow = new ProcessWindow(importer);
                processWindow.Owner = this;
                processWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void GrayDosBrowse_Click(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = grayDosBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = grayDosBrowseDialog.FileName;
                grayDosTextBox.Text = filename;
            }
        }

        private void GrayBitmapBrowse_Click(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = grayFileBrowseDialog.ShowDialog();
            if (result == true)
            {
                string filename = grayFileBrowseDialog.FileName;
                grayBitmapTextBox.Text = filename;
            }
        }

        private void GrayDosTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                grayDosTextBox.Text = fileNames[0];
            }
        }

        private void GrayDosTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void GrayBitmapTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                grayBitmapTextBox.Text = fileNames[0];
            }
        }

        private void GrayBitmapTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}