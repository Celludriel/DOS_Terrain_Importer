namespace DosTerrainImporter.Model
{
    public abstract class HeightMap
    {
        public abstract int Height { get; }

        public abstract int Width { get; }

        public abstract float GetHeight(int x, int y);

        public abstract float getMinimumElevation();

        public abstract float getMaximumElevation();

        public virtual void Dispose()
        {
        }
    }
}
