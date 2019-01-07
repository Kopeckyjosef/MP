namespace TheGameNamespace.Objects.MapObject.TerrainObject
{
    public class TestWallFront : Wall
    {
        public TestWallFront(Coordinates coordinates) : base(coordinates)
        {
            this.TerrainType = TerrainType.FrontWall;
            this.pathToTexture = "frontwall";
        }
    }
}
