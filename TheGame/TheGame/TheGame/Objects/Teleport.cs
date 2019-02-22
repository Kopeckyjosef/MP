using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;
using TheGameNamespace.Objects.MapObject;

namespace TheGame.Objects
{
    public class Teleport : Terrain
    {
        private Coordinates spawnCoordinates;
        private string destinationName;
        public Teleport(Coordinates coordinates, string pathToTexture, TerrainType terrainType, Coordinates spawnCoordinates, string destinationName) : base(coordinates, pathToTexture, terrainType, false, true)
        {
            this.spawnCoordinates = spawnCoordinates;
            this.destinationName = destinationName;
        }
        public override void OnActivation()
        {
            Access.Gamebody.LoadNewLevel(this.destinationName);
            GraficStuff.Player.Coordinates = this.spawnCoordinates;
        }
    }
}
