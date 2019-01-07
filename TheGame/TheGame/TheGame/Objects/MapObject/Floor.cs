namespace TheGameNamespace.Objects.MapObject
{
    public class Floor : Terrain
    {
        public Floor(Coordinates coordinates) : base (coordinates)
        {
            this.IsCrossable = true;
            this.TerrainType = TerrainType.Floor;
        }
    }
}
