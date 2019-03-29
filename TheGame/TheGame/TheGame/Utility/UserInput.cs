using Microsoft.Xna.Framework;
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
        private List<Keys> alreadyPressed = new List<Keys>();

        private int timer;
        private int attackTimer;
        private List<Keys> alreadyUsed = new List<Keys>();
        public UserInput(Player player)
        {
            this.player = player;
            this.timer = 0;
            this.attackTimer = 0;
        }

        public void GetUserInput(GameTime gameTime)
        {
            this.timer += gameTime.ElapsedGameTime.Milliseconds;
            if (this.attackTimer > 0)
            {
                this.attackTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
            this.lastKeyboard = Keyboard.GetState();
            if (Pause.IsPaused)
            {
                if (Pause.PauseType == PauseType.Inventory)
                {
                    if (this.lastKeyboard.IsKeyUp(Keys.I))
                    {
                        this.alreadyPressed.Remove(Keys.I);
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.I) && !this.alreadyPressed.Contains(Keys.I))
                    {
                        Pause.UnPause();
                        this.alreadyPressed.Add(Keys.I);
                    }
                    if (this.lastKeyboard.IsKeyUp(Keys.D))
                    {
                        this.alreadyPressed.Remove(Keys.D);
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.D) && !this.alreadyPressed.Contains(Keys.D))
                    {
                        InventorySelection.Right();
                        this.alreadyPressed.Add(Keys.D);
                    }
                    if (this.lastKeyboard.IsKeyUp(Keys.A))
                    {
                        this.alreadyPressed.Remove(Keys.A);
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.A) && !this.alreadyPressed.Contains(Keys.A))
                    {
                        InventorySelection.Left();
                        this.alreadyPressed.Add(Keys.A);
                    }
                    if (this.lastKeyboard.IsKeyUp(Keys.W))
                    {
                        this.alreadyPressed.Remove(Keys.W);
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.W) && !this.alreadyPressed.Contains(Keys.W))
                    {
                        InventorySelection.Up();
                        this.alreadyPressed.Add(Keys.W);
                    }
                    if (this.lastKeyboard.IsKeyUp(Keys.S))
                    {
                        this.alreadyPressed.Remove(Keys.S);
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.S) && !this.alreadyPressed.Contains(Keys.S))
                    {
                        InventorySelection.Down();
                        this.alreadyPressed.Add(Keys.S);
                    }
                    if (this.lastKeyboard.IsKeyUp(Keys.Q))
                    {
                        this.alreadyPressed.Remove(Keys.Q);
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.Q) && !this.alreadyPressed.Contains(Keys.Q))
                    {
                        GraficStuff.Player.Inventory.DropItem();
                        this.alreadyPressed.Add(Keys.Q);
                    }
                    if (this.lastKeyboard.IsKeyUp(Keys.E))
                    {
                        this.alreadyPressed.Remove(Keys.E);
                    }
                    if (this.lastKeyboard.IsKeyDown(Keys.E) && !this.alreadyPressed.Contains(Keys.E))
                    {
                        GraficStuff.Player.Inventory.Equip();
                        this.alreadyPressed.Add(Keys.E);
                    }
                }
            }
            else
            {
                if (this.lastKeyboard.IsKeyDown(Keys.D))
                {
                    Collision.MovePlayer(new Vector((float)(GraficStuff.Player.speed * gameTime.ElapsedGameTime.Milliseconds / 1000), 0));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.A))
                {
                    Collision.MovePlayer(new Vector((float)(GraficStuff.Player.speed * gameTime.ElapsedGameTime.Milliseconds / 1000 * -1), 0));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.W))
                {
                    Collision.MovePlayer(new Vector(0, (float)(GraficStuff.Player.speed * gameTime.ElapsedGameTime.Milliseconds / 1000 * -1)));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.S))
                {
                    Collision.MovePlayer(new Vector(0, (float)(GraficStuff.Player.speed * gameTime.ElapsedGameTime.Milliseconds / 1000)));
                }
                if (this.lastKeyboard.IsKeyDown(Keys.Q))
                {
                    Access.Gamebody.LoadNewLevel("Map");
                }
                if (this.lastKeyboard.IsKeyUp(Keys.I))
                {
                    this.alreadyPressed.Remove(Keys.I);
                }
                if (this.lastKeyboard.IsKeyDown(Keys.I) && !this.alreadyPressed.Contains(Keys.I))
                {
                    Pause.PauseGame(PauseType.Inventory);
                    this.alreadyPressed.Add(Keys.I);
                }
                if (this.lastKeyboard.IsKeyDown(Keys.J))
                {
                    if (this.attackTimer <= 0)
                    {
                        Collision.Attack();
                        this.attackTimer = 500;
                    }
                }
                if (this.lastKeyboard.IsKeyDown(Keys.E))
                {
                    Collision.ActivateTile();
                }
            }
            if (this.timer >= 1000)
            {
                this.timer = this.timer - 1000;
            }
        }
    }
}
