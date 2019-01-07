using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.Objects;
using TheGame.Objects.Characters;
using TheGame.Utility;
using TheGameNamespace.Objects;
using TheGameNamespace.Utility;

namespace TheGameNamespace.GameObjects
{
    public class GameBody
    {
        public static int Quests { get; set; }
        public static int Events { get; set; }
        private LevelBody LevelBody { get; set; }
        public Player player { get; private set; }
        public GameBody(ContentManager contentManager)
        {
            this.player = new Player(new Coordinates(2, 2));
        }
        public void LoadNewLevel(string mapName, ContentManager content)
        {
            Map map = MapController.GetMap(mapName, content);
            this.LevelBody = new LevelBody(map);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.LevelBody.Draw();
            if (Pause.IsPaused && Pause.PauseType == PauseType.Inventory)
            {
                this.player.Inventory.DrawInventory();
            }
        }
        public void OnUpdate()
        {
            this.LevelBody.OnUpdate();
        }
        public Map returnMap()
        {
            return this.LevelBody.returnMap();
        }
        public List<NPC> returnNPCs()
        {
            return this.LevelBody.returnNPCs();
        }
        public List<Enemy> returnEnemies()
        {
            return this.LevelBody.returnEnemies();
        }
    }
}
