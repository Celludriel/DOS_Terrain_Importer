using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace DosTerrainImporter.Importer.Dos2
{
    class PatchFileWriter
    {
        public int WritePatchFile(String patchFileName, Bitmap bmp, float minHeight, float maxHeight, int counter)
        {
            byte[] patchFileContents = File.ReadAllBytes(patchFileName);
            using (MemoryStream ms = new MemoryStream(patchFileContents))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    //Read Pversion4 and Patch version
                    byte[] fileHeaderInformation = br.ReadBytes(12);
                    using (BinaryWriter bw = new BinaryWriter(File.Open(patchFileName, FileMode.Create)))
                    {
                        bw.Write(fileHeaderInformation);
                        for (int j = 0; j < bmp.Height; j++)
                        {
                            for (int i = 0; i < bmp.Width; i++, counter++)
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
                                bw.Write(br.ReadByte());
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return counter;
        }
    }
}
