using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Utility
{
    public enum PauseType
    {
        Inventory,
        Conversation
    }
    public static class Pause
    {
        public static bool IsPaused { get; private set; }
        public static PauseType PauseType { get; private set; }

        public static void PauseGame(PauseType pauseType)
        {
            Pause.PauseType = pauseType;
            Pause.IsPaused = true;
        }

        public static void UnPause()
        {
            Pause.IsPaused = false;
        }
    }
}
