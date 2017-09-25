using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;


namespace DosTerrainImporter.Importer
{
    class Dos2GrayScaleImporter : TerrainImporter
    {
        Bitmap bmp = null;
        String patchFileName = null;
        float minHeight;
        float maxHeight;
        int maxWriteOperations = 0;

        public Dos2GrayScaleImporter(String patchFileName, String bitmapSourceFile, float minHeight, float maxHeight)
        {
            this.bmp = new Bitmap(bitmapSourceFile);
            this.maxWriteOperations = getMaximumWriteOperations();
            this.patchFileName = patchFileName;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
        }

        public override void execute(object sender, DoWorkEventArgs e)
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
                                if (counter % 100 == 0 || counter == this.maxWriteOperations)
                                {
                                    (sender as BackgroundWorker).ReportProgress(counter);
                                }
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

        public override int getMaximumWriteOperations()
        {
            return bmp.Height * bmp.Width;
        }
    }
}
