using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TheGameNamespace.GameFlow;
using TheGameNamespace.GameObjects;
using TheGame.Objects.Characters;
using TheGame.Utility;
using System.Threading;

namespace TheGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        UserInput userInput;
        GameBody gameBody;
        private int windowHeight = 700;
        private int windowWidth = 1200;
        private Texture2D background;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            this.background = this.Content.Load<Texture2D>(@"background");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GraficStuff.Initialize(this.spriteBatch, this.Content, windowWidth, windowHeight);
            BottomBar.Init();
            GameStarter.Initialize();
            this.gameBody = GameStarter.ReturnGameBody(this.Content);
            GraficStuff.Player = this.gameBody.player;
            this.gameBody.LoadNewLevel("StartCrypt");
            Access.SetGameBody(this.gameBody);
            Collision.Init();
            this.userInput = new UserInput(this.gameBody.player);
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            base.Initialize();
        }
        protected override void LoadContent()
        {
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            this.gameBody.OnUpdate(gameTime);
            this.userInput.GetUserInput(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);     
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            GraficStuff.SpriteBatch.Draw(this.background, new Rectangle(0, 0, this.windowWidth, this.windowHeight), Color.White);
            this.gameBody.Draw(spriteBatch);
            BottomBar.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
