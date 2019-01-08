using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGame.Objects.Characters;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class GraficStuff
    {
        public static readonly int Scale = 3;
        public static Player Player;
        public static int windowHeight;
        public static int windowWidth;
        public static SpriteBatch SpriteBatch { get; private set; }
        public static Offset WindowOffset { get; private set; }
        public  static ContentManager Content { get; private set; }
        public static void Initialize(SpriteBatch spriteBatch, ContentManager content, int windowWidth, int windowHeight)
        {
            GraficStuff.SpriteBatch = spriteBatch;
            GraficStuff.Content = content;
            GraficStuff.WindowOffset = new Offset(windowWidth / 2 - 8, windowHeight / 2 - 4);
            GraficStuff.windowHeight = windowHeight;
            GraficStuff.windowWidth = windowWidth;
        }
    }
}
