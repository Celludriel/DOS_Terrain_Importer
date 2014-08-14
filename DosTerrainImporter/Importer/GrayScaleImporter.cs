using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace DosTerrainImporter.Importer
{
    class GrayScaleImporter : TerrainImporter
    {
        Bitmap bmp = null;
        String terrainFileName = null;
        float minHeight;
        float maxHeight;

        public GrayScaleImporter(String terrainFileName, String sourceFileName, float minHeight, float maxHeight)
        {
            this.bmp = new Bitmap(sourceFileName);
            this.terrainFileName = terrainFileName;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
        }

        public override int getMaximumWriteOperations()
        {
            return bmp.Height * bmp.Width;
        }

        public override void execute(object sender, DoWorkEventArgs e)
        {
            byte[] fileContent = File.ReadAllBytes(terrainFileName);
            using (MemoryStream ms = new MemoryStream(fileContent))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    UInt32 heightmapSize = br.ReadUInt32();
                    if (bmp.Width * bmp.Height * 4 != heightmapSize)
                    {
                        throw new Exception("Error: The heightmap doesn't have a correct size.");
                    }
                    using (BinaryWriter bw = new BinaryWriter(File.Open(terrainFileName, FileMode.Create)))
                    {
                        bw.Write(heightmapSize);
                        for (int j = 0, counter = 1; j < bmp.Height; j++)
                        {
                            for (int i = 0; i < bmp.Width; i++, counter++)
                            {
                                br.ReadSingle();
                                System.Drawing.Color col = bmp.GetPixel(bmp.Width - 1 - i, j);
                                float v = (float)(col.B) / 255.0F; // range [0; 1]
                                v = v * (maxHeight - minHeight); // range [0; 25]
                                v = v + minHeight; // range [-1; 24]
                                bw.Write(v);
                                if (counter % 100 == 0 || counter == getMaximumWriteOperations())
                                {
                                    (sender as BackgroundWorker).ReportProgress(counter);
                                }
                            }
                        }
                        while (true)
                        {
                            try
                            {
                                bw.Write(br.ReadUInt32());
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
