using Microsoft.Xna.Framework;
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

        private Player mainPlayer;

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
            IsMouseVisible = false;
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

            // Player constructor.
            mainPlayer = new Player(new Rectangle(870, 510, 100, 100), menuLogo, null, null);

            userInterface = new UI(backgroundHealthUI, foregroundHealthUI, true, 100, 100, font, 8, 8); //Creates a UI object. Values to be updated later. 
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

                    userInterface.Update(mainPlayer.Health, mainPlayer.Ammo); //Updates the UI. Values to be updated later

                    if (kbState.IsKeyDown(Keys.R)) // A temporary way to instantly lose the game. Or maybe an unintentional feature!!!
                    {
                        currentGameState = GameState.GameOver;
                    }
                    if (kbState.IsKeyDown(Keys.Escape)) // A way to pause the game.
                    {
                        currentGameState = GameState.Pause;
                    }
                    
                    // Ends the game when the player's HP falls below one.
                    if (mainPlayer.Health <= 0)
                    {
                        currentGameState = GameState.GameOver;
                    }

                    mainPlayer.Update(gameTime);
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

            //Draws reticle
            MouseState mState = Mouse.GetState();
            _spriteBatch.Draw(gameReticle, new Rectangle(mState.X - 25, mState.Y - 25, 50, 50), Color.White);

            switch (currentGameState)
            {
                case GameState.Menu:

                    double xScale = _graphics.PreferredBackBufferWidth / 800.0;
                    double yScale = _graphics.PreferredBackBufferHeight / 480.0;

                    _spriteBatch.Draw(menuLogo, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuLogo.Width * (int)xScale / 10) / 2), 20, (menuLogo.Width / 10) * (int)xScale, (menuLogo.Height / 10) * (int)yScale), Color.White);
                    _spriteBatch.Draw(menuPlay, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width * (int)xScale / 10) / 2), 125, (menuPlay.Width / 10) * (int)xScale, (menuPlay.Height / 10) * (int)yScale), Color.White);
                    _spriteBatch.Draw(menuOptions, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOptions.Width * (int)xScale / 10) / 2), 270, (menuOptions.Width / 10) * (int)xScale, (menuOptions.Height / 10) * (int)yScale), Color.White);
                    _spriteBatch.Draw(menuQuit, new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width / 10) * (int)xScale / 2), 375, (menuQuit.Width / 10) * (int)xScale, (menuQuit.Height / 10) * (int)yScale), Color.White);

                    _spriteBatch.DrawString(font, "Menu", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);

                    break;
                case GameState.Game:
                    mainPlayer.Draw(_spriteBatch);
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