namespace TheGameNamespace.Objects.MapObject.TerrainObject
{
    public class TestWallLeft : Wall
    {
        public TestWallLeft(Coordinates coordinates) : base(coordinates)
        {
            this.TerrainType = TerrainType.LeftWall;
            this.pathToTexture = "leftwall";
        }
    }
}
