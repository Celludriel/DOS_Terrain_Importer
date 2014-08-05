using System;
using System.IO;
using L3dtFileManager.Hff;

namespace DosTerrainImporter.Model
{
    internal class HffHeightMap : HeightMap
    {
        private HffFile file;

        public override int Width
        {
            get
            {
                return (int)file.header.width;
            }
        }

        public override int Height
        {
            get
            {
                return (int)file.header.height;
            }
        }

        public HffHeightMap(HffFile hffFile)
        {
            this.file = hffFile;
        }

        public override float getMaximumElevation()
        {
            return 1f;
        }

        public override float getMinimumElevation()
        {
            return 1f;
        }

        public override float GetHeight(int x, int y)
        {
            return file.getPixelAt((uint)x+1,(uint)y+1).data;
        }

        public override void Dispose()
        {
            this.file = null;
        }
    }
}