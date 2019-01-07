using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGame.Objects.Characters;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public class UserInput
    {
        private KeyboardState lastKeyboard;
        private Player player;
        private Collision collision;
        public UserInput(Player player, Collision collision)
        {
            this.player = player;
            this.collision = collision;
        }

        public void GetUserInput()
        {
            if (Pause.IsPaused)
            {
                if (Pause.PauseType == PauseType.Inventory)
                {
                    this.lastKeyboard = Keyboard.GetState();
                    if (this.lastKeyboard.IsKeyDown(Keys.I))
                    {
                        Pause.UnPause();
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.D))
                    {
                        InventorySelection.Right();
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.A))
                    {
                        InventorySelection.Left();
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.W))
                    {
                        InventorySelection.Up();
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.S))
                    {
                        InventorySelection.Down();
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.E))
                    {
                        GraficStuff.Player.Inventory.Equip();
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.Q))
                    {
                        GraficStuff.Player.Inventory.DropItem();
                    }
                }
            }
            else
            {
                this.lastKeyboard = Keyboard.GetState();
                if (this.lastKeyboard.IsKeyDown(Keys.D))
                {
                    this.collision.MovePlayer(new Vector(0.3F, 0));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.A))
                {
                    this.collision.MovePlayer(new Vector(-0.3F, 0));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.W))
                {
                    this.collision.MovePlayer(new Vector(0, -0.3F));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.S))
                {
                    this.collision.MovePlayer(new Vector(0, 0.3F));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.I))
                {
                    Pause.PauseGame(PauseType.Inventory);
                }
                if (this.lastKeyboard.IsKeyDown(Keys.E))
                {
                    this.collision.ActivateTile();
                }
            }
        }
    }
}
