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

namespace TheGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Collision collision;
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

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.background = this.Content.Load<Texture2D>(@"background");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GraficStuff.Initialize(this.spriteBatch, this.Content, windowWidth, windowHeight);
            GameStarter.Initialize();
            // TODO: Add your initialization logic here
            this.gameBody = GameStarter.ReturnGameBody(this.Content);
            this.gameBody.LoadNewLevel("Map", this.Content);
            Access.SetGameBody(this.gameBody);
            this.userInput = new UserInput(this.gameBody.player, new Collision(this.gameBody.returnMap(), this.gameBody.returnNPCs(), this.gameBody.returnEnemies(), this.gameBody.player));
            EnemyCollision.Initialize(this.gameBody.returnMap(), this.gameBody.player);
            GraficStuff.Player = this.gameBody.player;
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.gameBody.OnUpdate();

            // TODO: Add your update logic here
            this.userInput.GetUserInput();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);     
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            GraficStuff.SpriteBatch.Draw(this.background, new Rectangle(0, 0, this.windowWidth, this.windowHeight), Color.White);
            this.gameBody.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
