using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameNamespace.GameObjects;

namespace TheGame.Utility
{
    public static class Access
    {
        public static GameBody Gamebody;

        public static void SetGameBody(GameBody gamebody)
        {
            Access.Gamebody = gamebody;
        }
    }
}
