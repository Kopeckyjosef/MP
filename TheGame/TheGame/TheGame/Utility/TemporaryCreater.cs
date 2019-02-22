using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class TemporaryCreater
    {
        public static Temporary returnWeaponSlash(bool isFacingRight, Coordinates coordinates)
        {
            return new Temporary(0.2, new GameTexture(GraficStuff.Content.Load<Texture2D>("WeaponSlash"), new Offset(-8, -25)), isFacingRight, coordinates);
        }
    }
}
