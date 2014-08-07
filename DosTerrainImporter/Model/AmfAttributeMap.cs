using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L3dtFileManager;
using L3dtFileManager.Amf;

namespace DosTerrainImporter.Model
{
    public class AmfAttributeMap
    {
        private AmfFile file;
        Dictionary<byte,byte> landType = new Dictionary<byte, byte>();

        public AmfAttributeMap(AmfFile amfFile)
        {
            this.file = amfFile;          
        }

        public int Height
        {
            get
            {
                return this.file.height;
            }
        }

        public int Width
        {
            get
            {
                return this.file.width;
            }
        }

        public byte GetClimateIdAtPixel(int x, int y)
        {
            AmfPixelInfo pixel = this.file.getPixelAt((uint)x, (uint)y);
            return pixel.climateId;
        }

        public byte GetLandTypeIdAtPixel(int x, int y)
        {
            AmfPixelInfo pixel = this.file.getPixelAt((uint)x, (uint)y);
            return pixel.landTypeId;
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
