﻿using Microsoft.Xna.Framework.Graphics;
using TheGame.Utility;
using TheGame.Objects;
using System;

namespace TheGameNamespace.Objects.MapObject
{
    public enum TerrainType
    {
        FrontWall,
        LeftWallShort,
        BackWall,
        RightWall,
        LeftWall,
        BackWallShort,
        Dropped,
        Floor,
        Ceiling,
        Chest,
        WallRightFull
    }
    public class Terrain : HasCoordinates
    {
        protected GameTexture texture { get; set; }
        protected string pathToTexture { get; set; }
        public bool IsActivateble { get; protected set; }
        public bool IsCrossable { get; protected set; }
        public TerrainType TerrainType { get; protected set; }
        public Terrain(Coordinates coordinates, string pathToTexture, TerrainType terrainType, bool isCrossable, bool isActivateble)
        {
            this.Coordinates = coordinates;
            this.pathToTexture = pathToTexture;
            this.TerrainType = terrainType;
            this.IsCrossable = isCrossable;
            this.IsActivateble = isActivateble;
        }

        public void Initialize()
        {
            Offset offSet = new Offset();
            switch (this.TerrainType)
            {
                case TerrainType.Floor: offSet.x = 0; offSet.y = 0; break;
                case TerrainType.FrontWall: offSet.x = 8; offSet.y = -6F; break;
                case TerrainType.BackWall: offSet.x = 0F; offSet.y = -24F; break;
                case TerrainType.BackWallShort: offSet.x = 0F; offSet.y = 2F; break;
                case TerrainType.LeftWall: offSet.x = 16; offSet.y = -32F; break;
                case TerrainType.RightWall: offSet.x = 0; offSet.y = -6F; break;
                case TerrainType.LeftWallShort: offSet.x = 16; offSet.y = -6F; break;
                case TerrainType.Ceiling: offSet.x = 0; offSet.y = -32F; break;
                case TerrainType.WallRightFull: offSet.x = 0; offSet.y = -32F; break;
                default: offSet.x = 0; offSet.y = 0; break;
            }
            if (pathToTexture.Contains("WallLeftShort"))
            {
                var a = 1;
            }
            this.texture = new GameTexture(GraficStuff.Content.Load<Texture2D>(@"" + pathToTexture), offSet);
            if (this.texture == null)
            {
                this.texture = new GameTexture(GraficStuff.Content.Load<Texture2D>(@"floor"), offSet);
            }
        }
        public void Initialize(Offset customOffset)
        {
            this.texture = new GameTexture(GraficStuff.Content.Load<Texture2D>(@"" + pathToTexture), customOffset);
            if (this.texture == null)
            {
                this.texture = new GameTexture(GraficStuff.Content.Load<Texture2D>(@"floor"), customOffset);
            }
        }

        public override void Draw()
        {
            try
            {
                this.texture.Draw(this.Coordinates.x, this.Coordinates.y);
            }
            catch
            {

            }
        }

        public virtual void OnActivation() { }
    }
}
