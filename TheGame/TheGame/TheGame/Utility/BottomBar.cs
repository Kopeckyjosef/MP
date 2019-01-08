using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects;

namespace TheGame.Utility
{
    public static class BottomBar
    {
        private static Texture2D bottomBar;
        private static Texture2D health;
        private static Texture2D stamina;

        public static void Init()
        {
            bottomBar = GraficStuff.Content.Load<Texture2D>(@"bottomBar");
            health = GraficStuff.Content.Load<Texture2D>(@"bottomBarHealth");
            stamina = GraficStuff.Content.Load<Texture2D>(@"bottomBarStamina");
        }

        public static void Draw()
        {
            for (int i = 0; i < Math.Round(GraficStuff.Player.Health / (GraficStuff.Player.MaximumHealth / 100) / 3.3); i++)
            {
                GraficStuff.SpriteBatch.Draw(health, new Rectangle(0, (GraficStuff.windowHeight - GraficStuff.windowHeight / 4) - i * GraficStuff.windowHeight / 4 / health.Height, GraficStuff.windowWidth, GraficStuff.windowHeight / 4), Color.White);
            }
            for (int i = 0; i < Math.Round(GraficStuff.Player.Stamina / (GraficStuff.Player.MaximumHealth / 100) / 3.3); i++)
            {
                GraficStuff.SpriteBatch.Draw(stamina, new Rectangle(0, (GraficStuff.windowHeight - GraficStuff.windowHeight / 4) - i * GraficStuff.windowHeight / 4 / stamina.Height, GraficStuff.windowWidth, GraficStuff.windowHeight / 4), Color.White);
            }
            GraficStuff.SpriteBatch.Draw(bottomBar, new Rectangle(0, GraficStuff.windowHeight - GraficStuff.windowHeight / 4, GraficStuff.windowWidth, GraficStuff.windowHeight / 4), Color.White);
        }
    }
}
