using DosTerrainImporter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DosTerrainImporter.Importer
{
    class L3dtImporter
    {
        public void importL3dt(String dosFileName, String l3dtFileName, float minHeight, float maxHeight)
        {
            HeightMap heightMap = loadHeightMap(l3dtFileName);
            if (heightMap != null)
            {
                byte[] dosBinaryFileContent = File.ReadAllBytes(dosFileName);
                using (MemoryStream dosBinaryMemoryStream = new MemoryStream(dosBinaryFileContent))
                {
                    using (BinaryReader dosBinaryReader = new BinaryReader(dosBinaryMemoryStream))
                    {
                        UInt32 heightmapSize = dosBinaryReader.ReadUInt32();
                        using (BinaryWriter bw = new BinaryWriter(File.Open(dosFileName, FileMode.Create)))
                        {
                            bw.Write(heightmapSize);
                            int width = heightMap.Width;
                            int height = heightMap.Height;
                            float minElevation = heightMap.getMinimumElevation();
                            float maxElevation = heightMap.getMaximumElevation();
                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {
                                    dosBinaryReader.ReadSingle();
                                    float pixelHeight = heightMap.GetHeight(width - 1 - i, j);
                                    float baseValue = pixelHeight / (maxElevation - minElevation);
                                    pixelHeight = baseValue * (maxHeight - minHeight);
                                    bw.Write(pixelHeight);
                                }
                            }
                            while (true)
                            {
                                try
                                {
                                    bw.Write(dosBinaryReader.ReadUInt32());
                                }
                                catch (Exception ex)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
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
