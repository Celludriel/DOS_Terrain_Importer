using System.Drawing;

namespace DosTerrainImporter.Model
{
    public abstract class AttributeMap
    {
        public abstract int Height { get; }

        public abstract int Width { get; }

        public abstract object GetPixel(int x, int y);

        public virtual void Dispose()
        {
        }
    }
}
