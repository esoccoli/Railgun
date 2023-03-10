﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Railgun.RailgunGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;

        private Texture2D backgroundHealthUI;
        private Texture2D foregroundHealthUI;

        // Menu Textures
        private Texture2D menuLogo;        
        private Texture2D menuPlay;
        private Texture2D menuOptions;
        private Texture2D menuQuit;

        // Reticle
        private Texture2D gameReticle;

        private GameState currentGameState;

        private UI userInterface;

        private List<Projectile> playerBullets;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public enum GameState
        {
            Menu,
            Game,
            Pause,
            GameOver
        }

        protected override void Initialize()
        {
            #region Set Screen Resolution
            // I just set it to 1920x1080p cuz that's standard. We can change it later if needed, and full screen it when we're done.

            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            #endregion

            currentGameState = GameState.Menu;
            font = this.Content.Load<SpriteFont>("Mynerve24");

            GameTime gameTime = new GameTime();

            //UI Stuff
            backgroundHealthUI = Content.Load<Texture2D>("WhiteHealthSquare");
            foregroundHealthUI = Content.Load<Texture2D>("RedHealthSquare");

            //Game Menu Stuff
            menuLogo = Content.Load<Texture2D>("menuLogo");
            menuPlay = Content.Load<Texture2D>("menuPlay");
            menuOptions = Content.Load<Texture2D>("menuOptions");
            menuQuit = Content.Load<Texture2D>("menuQuit");

            //Game Reticle
            gameReticle = Content.Load<Texture2D>("gameReticle");

            //Creates a player - update later
            Player mainPlayer = new Player(new Rectangle(0, 0, 0, 0), backgroundHealthUI, gameTime, null, null);

            userInterface = new UI(backgroundHealthUI, foregroundHealthUI, true, 100, 100, font, 12, 12); //Creates a UI object. Values to be updated later. 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();

            switch (currentGameState)
            {
                case GameState.Menu:

                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Game;
                    }

                    break;
                case GameState.Game:

                    userInterface.Update(90, 10); //Updates the UI. Values to be updated later

                    if (kbState.IsKeyDown(Keys.R))
                    {
                        currentGameState = GameState.GameOver;
                    }
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        currentGameState = GameState.Pause;
                    }
                    
                    //Add this when we have Player working

                    //if (mainPlayer.Health <= 0)
                    //{
                    //    currentGameState = GameState.GameOver;
                    //}

                    break;
                case GameState.Pause:

                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Game;
                    }

                    break;
                case GameState.GameOver:

                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Game;
                    }

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            _spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.Menu:

                    double xScale = _graphics.PreferredBackBufferWidth / 800.0;
                    double yScale = _graphics.PreferredBackBufferHeight / 480.0;

                    _spriteBatch.Draw(menuLogo, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuLogo.Width / 10) / 2), 0, (menuLogo.Width / 10) * (int)xScale, (menuLogo.Height / 10) * (int)yScale), Color.White);
                    _spriteBatch.Draw(menuPlay, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width / 10) / 2), 125, (menuPlay.Width / 10) * (int)xScale, (menuPlay.Height / 10) * (int)yScale), Color.White);
                    _spriteBatch.Draw(menuOptions, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOptions.Width / 10) / 2), 270, (menuOptions.Width / 10) * (int)xScale, (menuOptions.Height / 10) * (int)yScale), Color.White);
                    _spriteBatch.Draw(menuQuit, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width / 10) / 2), 375, (menuQuit.Width / 10) * (int)xScale, (menuQuit.Height / 10) * (int)yScale), Color.White);

                    _spriteBatch.DrawString(font, "Menu", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);

                    break;
                case GameState.Game:

                    _spriteBatch.DrawString(font, "Game", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);
                    userInterface.Draw(_spriteBatch); //Draws UI

                    break;
                case GameState.Pause:

                    _spriteBatch.DrawString(font, "Pause", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);

                    break;
                case GameState.GameOver:

                    _spriteBatch.DrawString(font, "Game Over", new Vector2(_graphics.PreferredBackBufferWidth - 175, 20), Color.White);

                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}