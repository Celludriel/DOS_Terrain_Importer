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
        private const int ONE_PATCH_MAX_DIMENSION = 33;
        private const string PATCH_EXTENSION = ".patch";
        private const int MAX_PERCENT = 100;

        PatchFileWriter patchFileWriter = new PatchFileWriter();
        Bitmap bmp = null;
        String dataFileName = null;
        float minHeight;
        float maxHeight;
        List<String> patchFiles = new List<String>();

        public Dos2GrayScaleImporter(String dataFileName, String bitmapSourceFile, float minHeight, float maxHeight)
        {
            this.bmp = new Bitmap(bitmapSourceFile);
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
                    patchFiles.Add(Path.GetFileName(file));
                }
            }            
        }

        private void WriteTerrain(object sender)
        {
            int patchFilesDone = 0;
            foreach (String patchFile in patchFiles)
            {
                String fileUuid = Path.GetFileNameWithoutExtension(patchFile);
                String[] fileParts = fileUuid.Split('_');

                int patchLocationX = Int32.Parse(fileParts[1]);
                int patchLocationY = Int32.Parse(fileParts[2]);
                
                patchFileWriter.WritePatchFile(patchFile, bmp, patchLocationX, patchLocationY, minHeight, maxHeight);

                patchFilesDone = patchFilesDone + 1;
                int progress = (patchFilesDone / patchFiles.Count) * 100;
                (sender as BackgroundWorker).ReportProgress(progress);
            }
        }

        public override int getMaximumWriteOperations()
        {
            return MAX_PERCENT;
        }
    }
}
