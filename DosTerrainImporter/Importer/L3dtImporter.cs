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

namespace DosTerrainImporter.Importer
{
    class L3dtImporter
    {
        public void importL3dt(String dosFileName, String l3dtFileName, float minHeight, float maxHeight)
        {
            HeightMap heightMap = loadHeightMap(l3dtFileName);
            if (heightMap != null)
            {
                UInt32 width = (UInt32)heightMap.Width;
                UInt32 height = (UInt32)heightMap.Height;
                DosTerrain dosTerrain = new DosTerrainParser().ReadDosTerrain((width*2) - 2, (height*2) - 2, dosFileName);
                float minElevation = heightMap.getMinimumElevation();
                float maxElevation = heightMap.getMaximumElevation();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        float pixelHeight = heightMap.GetHeight(x, y);
                        float baseValue = pixelHeight / (maxElevation - minElevation);
                        pixelHeight = baseValue * (maxHeight - minHeight);
                        HeigthMapEditor.SetHeightAt(dosTerrain, (uint)x, (uint)y, pixelHeight);
                    }
                }
                DosTerrainWriter writer = new DosTerrainWriter();
                writer.WriteDosTerrain(dosTerrain, dosFileName);
            }
            else
            {
                throw new Exception("Error: Failed to load heightmap");
            }
        }

        private HeightMap loadHeightMap(string l3dtFileName)
        {
            if (l3dtFileName.EndsWith("hfz") || l3dtFileName.EndsWith("hf2.gz") || l3dtFileName.EndsWith("hf2"))
            {
                return (HeightMap)new Hf2HeightMap(l3dtFileName);
            }
            else if (l3dtFileName.EndsWith("hff"))
            {
                return (HeightMap)new HffHeightMap(l3dtFileName);
            }
            return null;
        }
    }
}
