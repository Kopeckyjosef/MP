namespace TheGameNamespace.Objects.MapObject.TerrainObject
{
    public class TestWallRight : Wall
    {
        public TestWallRight(Coordinates coordinates) : base(coordinates)
        {
            this.TerrainType = TerrainType.RightWall;
            this.pathToTexture = "rightwall";
        }
    }
}
