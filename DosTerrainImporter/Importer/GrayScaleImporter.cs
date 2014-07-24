using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DosTerrainImporter.Importer
{
    class GrayScaleImporter
    {
        public void importGreyScale(String dosFileName, String imageFileName, float minHeight, float maxHeight)
        {
            Bitmap bmp = new Bitmap(imageFileName);
            byte[] fileContent = File.ReadAllBytes(dosFileName);
            using (MemoryStream ms = new MemoryStream(fileContent))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    UInt32 heightmapSize = br.ReadUInt32();
                    if (bmp.Width * bmp.Height * 4 != heightmapSize)
                    {
                        throw new Exception("Error: The heightmap doesn't have a correct size.");
                    }
                    using (BinaryWriter bw = new BinaryWriter(File.Open(dosFileName, FileMode.Create)))
                    {
                        bw.Write(heightmapSize);
                        for (int j = 0; j < bmp.Height; j++)
                        {
                            for (int i = 0; i < bmp.Width; i++)
                            {
                                br.ReadSingle();
                                System.Drawing.Color col = bmp.GetPixel(bmp.Width - 1 - i, j);
                                float v = (float)(col.B) / 255.0F; // range [0; 1]
                                v = v * (maxHeight - minHeight); // range [0; 25]
                                v = v + minHeight; // range [-1; 24]
                                bw.Write(v);
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
