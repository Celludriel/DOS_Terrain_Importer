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

        public void WritePatchFile(String patchFileName, Bitmap bmp, int patchLocationX, int patchLocationY, float minHeight, float maxHeight)
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
                        for (int j = 0; j < ONE_PATCH_MAX_DIMENSION; j++)
                        {
                            for (int i = 0; i < ONE_PATCH_MAX_DIMENSION; i++)
                            {
                                br.ReadSingle();

                                int pixelLocationX = (ONE_PATCH_MAX_DIMENSION * patchLocationX) + i;
                                int pixelLocationY = (ONE_PATCH_MAX_DIMENSION * patchLocationY) + j;
 
                                System.Drawing.Color col = bmp.GetPixel(pixelLocationY, pixelLocationX);
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
        }
    }
}
