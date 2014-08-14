using L3dtFileManager.L3dt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DosTerrainImporter.Model
{
    public static class HeightMapFactory
    {
        public static HeightMap GetInstance(L3dtFile l3dtProject)
        {
            if (l3dtProject.heightMapType == L3dtFile.HeightMapType.HFF)
            {
                return new HffHeightMap(l3dtProject.HffFile);
            }
            else if (l3dtProject.heightMapType == L3dtFile.HeightMapType.HFZ)
            {
                return new Hf2HeightMap(l3dtProject.HfzFile);
            }
            return null;
        }       
    }
}
