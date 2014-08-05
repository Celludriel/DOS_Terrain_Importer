using DosTerrainImporter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DosTerrainLib.Model;
using DosTerrainLib.Helper;
using DosTerrainLib;
using System.ComponentModel;
using L3dtFileManager.L3dt;

namespace DosTerrainImporter.Importer
{
    public class L3dtImporter : TerrainImporter
    {
        private L3dtFile l3dtProject = null;
        private DosTerrain dosTerrain = null;
        private HeightMap heightMap = null;
        private String terrainFileName;
        private float minHeight;
        private float maxHeight;

        public L3dtImporter(String terrainFileName, String sourceFileName, float minHeight, float maxHeight)
        {
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
            this.terrainFileName = terrainFileName;
            this.l3dtProject = LoadL3dtProject(sourceFileName);
            if (l3dtProject == null)
            {
                throw new Exception("Error: Failed to load L3DT project");
            }
            this.heightMap = HeightMapFactory.GetInstance(l3dtProject);
            dosTerrain = new DosTerrainParser().ReadDosTerrain(((UInt32)heightMap.Width * 2) - 2, ((UInt32)heightMap.Height * 2) - 2, terrainFileName);
        }

        public override void execute(object sender, DoWorkEventArgs e)
        {
            UInt32 width = (UInt32)heightMap.Width;
            UInt32 height = (UInt32)heightMap.Height;
            DosTerrain dosTerrain = new DosTerrainParser().ReadDosTerrain((width * 2) - 2, (height * 2) - 2, terrainFileName);
            float minElevation = heightMap.getMinimumElevation();
            float maxElevation = heightMap.getMaximumElevation();
            for (int y = 0, counter=1; y < height; y++)
            {
                for (int x = 0; x < width; x++, counter++)
                {
                    float pixelHeight = heightMap.GetHeight(x, y);
                    float baseValue = pixelHeight / (maxElevation - minElevation);
                    pixelHeight = baseValue * (maxHeight - minHeight);
                    HeigthMapEditor.SetHeightAt(dosTerrain, (uint)x, (uint)y, pixelHeight);
                    if (counter % 100 == 0 || counter == getMaximumWriteOperations())
                    {
                        (sender as BackgroundWorker).ReportProgress(counter);
                    }
                }
            }
            DosTerrainWriter writer = new DosTerrainWriter();
            writer.WriteDosTerrain(dosTerrain, terrainFileName);
        }

        public override int getMaximumWriteOperations()
        {
            return dosTerrain.HeightMapData.Length;
        }

        private L3dtFile LoadL3dtProject(string l3dtFileName)
        {
            L3dtFileManager.L3dtFileManager manager = new L3dtFileManager.L3dtFileManager();
            return manager.loadL3dtProject(l3dtFileName);
        }
    }
}
