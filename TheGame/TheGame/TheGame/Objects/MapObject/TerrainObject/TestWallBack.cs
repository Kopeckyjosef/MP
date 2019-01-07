namespace TheGameNamespace.Objects.MapObject.TerrainObject
{
    public class TestWallBack : Wall
    {
        public TestWallBack(Coordinates coordinates) : base(coordinates)
        {
            this.TerrainType = TerrainType.BackWall;
            this.pathToTexture = "backwall";
        }
    }
}
