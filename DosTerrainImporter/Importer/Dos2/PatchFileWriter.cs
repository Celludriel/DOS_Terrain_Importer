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
        private const int ONE_PATCH_MAX_DIMENSION = 33;

        public int WritePatchFile(String patchFileName, Bitmap bmp, int bitmap_j_offset, int bitmap_i_offset, float minHeight, float maxHeight, int counter)
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
                        for (int j = bitmap_j_offset; j < ONE_PATCH_MAX_DIMENSION; j++)
                        {
                            for (int i = bitmap_i_offset; i < ONE_PATCH_MAX_DIMENSION; i++, counter++)
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
