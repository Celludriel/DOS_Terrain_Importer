using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L3dtFileManager;
using L3dtFileManager.Hfz;

namespace DosTerrainImporter.Model
{
    internal class Hf2HeightMap : HeightMap
    {
        private HfzFile file;

        public Hf2HeightMap(HfzFile hfzFile)
        {
            this.file = hfzFile;
        }

        public override int Width
        {
            get
            {
                return Convert.ToInt32(this.file.header.nx);
            }
        }

        public override int Height
        {
            get
            {
                return Convert.ToInt32(this.file.header.ny);
            }
        }

        public override float getMaximumElevation()
        {
            return this.file.getMaxHeight();
        }

        public override float getMinimumElevation()
        {
            return this.file.getMinHeight();
        }

        public override void Dispose()
        {
            this.file = null;
        }

        public override float GetHeight(int x, int y)
        {
            return file.getPixelAt((uint)x + 1, (uint)y + 1);
        }
    }
}
