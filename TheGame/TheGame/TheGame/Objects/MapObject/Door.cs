namespace TheGameNamespace.Objects.MapObject
{
    class Door : Terrain
    {
        public Door(Coordinates coordinates) : base (coordinates)
        {
            this.IsCrossable = false;
            this.TerrainType = TerrainType.Floor;
        }
        public override void OnActivation()
        {
            /*this.map.terrain.Remove(this);
            this.map.floor.Add(this);*/
        }
    }
}
