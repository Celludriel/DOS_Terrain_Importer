using DosTerrainImporter.Importer.Dos2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;


namespace DosTerrainImporter.Importer
{
    class Dos2GrayScaleImporter : TerrainImporter
    {
        private const int MAX_FILE_OPERATIONS_FOR_ONE_PATCH = 1089;
        private const string PATCH_EXTENSION = ".patch";
        PatchFileWriter patchFileWriter = new PatchFileWriter();
        Bitmap bmp = null;
        String dataFileName = null;
        float minHeight;
        float maxHeight;
        int maxWriteOperations = 0;
        List<String> patchFiles = new List<String>();

        public Dos2GrayScaleImporter(String dataFileName, String bitmapSourceFile, float minHeight, float maxHeight)
        {
            this.bmp = new Bitmap(bitmapSourceFile);
            this.maxWriteOperations = getMaximumWriteOperations();
            this.dataFileName = dataFileName;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
        }

        public override void execute(object sender, DoWorkEventArgs e)
        {
            CreateListOfPatchFiles();
            WriteTerrain(sender);
        }

        private void CreateListOfPatchFiles()
        {
            String workingDirectory = Path.GetDirectoryName(dataFileName);
            String[] files = Directory.GetFiles(workingDirectory);
            String uuid = Path.GetFileNameWithoutExtension(dataFileName);

            foreach (String file in files)
            {
                if(file.Contains(uuid) && file.Contains(PATCH_EXTENSION))
                {
                    patchFiles.Add(Path.GetFileNameWithoutExtension(file));
                }
            }            
        }

        private void WriteTerrain(object sender)
        {
            int bitmap_j_offset = 0;
            int bitmap_i_offset = 0;

            int counter = patchFileWriter.WritePatchFile(dataFileName, bmp, bitmap_j_offset, bitmap_i_offset, minHeight, maxHeight, 1);

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
