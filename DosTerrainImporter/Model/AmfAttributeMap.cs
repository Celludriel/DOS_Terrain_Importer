using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L3dtFileManager;
using L3dtFileManager.Amf;

namespace DosTerrainImporter.Model
{
    public class AmfAttributeMap : AttributeMap
    {
        private AmfFile file;

        public AmfAttributeMap(string filename)
        {
            L3dtFileManager.L3dtFileManager manager = new L3dtFileManager.L3dtFileManager();
            if (filename.EndsWith(".amf.gz"))
            {
                this.file = manager.loadAmfFile(filename, FileFormat.COMPRESSED);
            }
            else if (filename.EndsWith(".amf"))
            {
                this.file = manager.loadAmfFile(filename, FileFormat.UNCOMPRESSED);
            }
            else
            {
                throw new Exception("Not a AMF map file");
            }
        }

        public override int Height
        {
            get
            {
                return this.file.height;
            }
        }

        public override int Width
        {
            get
            {
                return this.file.width;
            }
        }

        public string GetPixel(int x, int y)
        {
            AmfPixelInfo pixel = this.file.getPixelAt((uint)x + 1, (uint)y + 1);
            return pixel.climateId + "-" + pixel.landTypeId;
        }

        public List<String> getAllLandTypes()
        {
            List<string> landTypes = new List<string>();
            List<byte> climates = this.file.uniqueLandTypeIdProClimate.Keys.ToList();
            foreach (byte climate in climates)
            {
                List<byte> fileLandTypes = this.file.uniqueLandTypeIdProClimate[climate];
                foreach (byte landType in fileLandTypes)
                {
                    landTypes.Add(climate + "-" + landType);
                }
            }
            return landTypes;
        }
    }
}
