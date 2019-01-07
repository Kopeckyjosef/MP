using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameNamespace.GameObjects;

namespace TheGameNamespace.GameFlow
{
    public static class GameStarter
    {
        public static void Initialize()
        {

        }
        public static GameBody ReturnGameBody(ContentManager contentManager)
        {
            return new GameBody(contentManager);
        }
    }
}
