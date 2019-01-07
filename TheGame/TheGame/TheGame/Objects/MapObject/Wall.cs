namespace TheGameNamespace.Objects.MapObject
{
    public class Wall : Terrain
    {
        public Wall(Coordinates coordinates) : base (coordinates)
        {
            this.IsCrossable = false;
        }
    }
}
