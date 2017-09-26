using DosTerrainImporter.Importer.Dos2;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;


namespace DosTerrainImporter.Importer
{
    class Dos2GrayScaleImporter : TerrainImporter
    {
        private const int MAX_FILE_OPERATIONS_FOR_ONE_PATCH = 1089;

        PatchFileWriter patchFileWriter = new PatchFileWriter();
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
            int bitmap_j_offset = 0;
            int bitmap_i_offset = 0;

            int counter = patchFileWriter.WritePatchFile(patchFileName, bmp, bitmap_j_offset, bitmap_i_offset, minHeight, maxHeight, 1);

            if (counter % 100 == 0 || counter == this.maxWriteOperations)
            {
                (sender as BackgroundWorker).ReportProgress(counter);
            }
        }

        public override int getMaximumWriteOperations()
        {
            return MAX_FILE_OPERATIONS_FOR_ONE_PATCH;
        }
    }
}
