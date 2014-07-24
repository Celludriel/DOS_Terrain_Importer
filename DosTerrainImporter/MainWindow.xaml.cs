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

namespace DosTerrainImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog dlg1 = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.OpenFileDialog dlg2 = new Microsoft.Win32.OpenFileDialog();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float minHeight;
            float maxHeight;
            HeightMap heightMap = null;
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


            heightMap = loadHeightMap(l3dtFileName);
            if (heightMap == null)
            {
                MessageBox.Show("Error: Failed to load heightmap");
                return;
            }

            byte[] dosBinaryFileContent = File.ReadAllBytes(dosFileName);
            using (MemoryStream dosBinaryMemoryStream = new MemoryStream(dosBinaryFileContent))
            {
                using (BinaryReader dosBinaryReader = new BinaryReader(dosBinaryMemoryStream))
                {
                    UInt32 heightmapSize = dosBinaryReader.ReadUInt32();
                    using (BinaryWriter bw = new BinaryWriter(File.Open(dosFileName, FileMode.Create)))
                    {
                        bw.Write(heightmapSize);
                        int width = heightMap.Width;
                        int height = heightMap.Height;
                        float minElevation = heightMap.getMinimumElevation();
                        float maxElevation = heightMap.getMaximumElevation();
                        for (int j = 0; j < height; j++)
                        {
                            for (int i = 0; i < width; i++)
                            {
                                dosBinaryReader.ReadSingle();
                                float pixelHeight = heightMap.GetHeight(width - 1 - i, j);
                                float baseValue = pixelHeight / (maxElevation - minElevation);
                                pixelHeight = baseValue * (maxHeight - minHeight);
                                bw.Write(pixelHeight);
                            }
                        }
                        while (true)
                        {
                            try
                            {
                                bw.Write(dosBinaryReader.ReadUInt32());
                            }
                            catch (Exception ex)
                            {
                                break;
                            }
                        }
                        MessageBox.Show("Done");
                    }
                }
            }
        }

        private HeightMap loadHeightMap(string l3dtFileName)
        {
            if (l3dtFileName.EndsWith("hfz") || l3dtFileName.EndsWith("hf2.gz") || l3dtFileName.EndsWith("hf2"))
            {
                return (HeightMap) new Hf2HeightMap(l3dtFileName);
            }
            else if (l3dtFileName.EndsWith("hff"))
            {
                return (HeightMap) new HffHeightMap(l3dtFileName);
            }
            return null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = dlg1.ShowDialog();
            if (result == true)
            {
                string filename = dlg1.FileName;
                dosTextBox.Text = filename;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = dlg2.ShowDialog();
            if (result == true)
            {
                string filename = dlg2.FileName;
                l3dtTextBox.Text = filename;
            }
        }

        private void dosTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                dosTextBox.Text = fileNames[0];
            }
        }

        private void dosTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void l3dtTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                l3dtTextBox.Text = fileNames[0];
            }
        }

        private void l3dtTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

    }
}