using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Railgun.RailgunGame.Util;
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

        #region Menu Elements
        // Textures used to display the Menu.
        private Texture2D menuLogo;
        private Texture2D menuPlay;
        private Texture2D menuOpti;
        private Texture2D menuQuit;

        // Rectangles to make the Menu usable.
        private Rectangle logoRect;
        private Rectangle playRect;
        private Rectangle optiRect;
        private Rectangle quitRect;
        #endregion

        // Player, enemy, and projectile textures
        private Texture2D bulletTexture;

        // Reticle
        private Texture2D gameReticle;

        private GameState currentGameState;

        private UI userInterface;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Texture Loading
            //UI Stuff
            backgroundHealthUI = Content.Load<Texture2D>("WhiteHealthSquare");
            foregroundHealthUI = Content.Load<Texture2D>("RedHealthSquare");

            //Game Menu Stuff
            menuLogo = Content.Load<Texture2D>("menuLogo");
            menuPlay = Content.Load<Texture2D>("menuPlay");
            menuOpti = Content.Load<Texture2D>("menuOptions");
            menuQuit = Content.Load<Texture2D>("menuQuit");

            //Game Reticle
            gameReticle = Content.Load<Texture2D>("gameReticle");

            // Player, bullets, and enemies.
            bulletTexture = Content.Load<Texture2D>($"bulletTexture");

            #endregion

            //Creates a UI object. Values to be updated later. 
            mainPlayer = new Player(new Rectangle(870, 510, 100, 100), menuLogo, bulletTexture, null);
            userInterface = new UI(backgroundHealthUI, foregroundHealthUI, true, mainPlayer.Health, mainPlayer.MaxHealth, font, mainPlayer.Ammo, mainPlayer.MaxAmmo);
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.UpdateInputState();
            MouseState mState = Mouse.GetState();

            switch (currentGameState)
            {
                case GameState.Menu:

                    // This creates the default menu buttons

                    double xScale = _graphics.PreferredBackBufferWidth / 800.0;
                    double yScale = _graphics.PreferredBackBufferHeight / 480.0;

                    if (xScale < 1)
                    {
                        xScale = 1;
                    }
                    if (yScale < 1)
                    {
                        yScale = 1;
                    }

                    logoRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuLogo.Width * (int)xScale / 10) / 2), 20, (menuLogo.Width / 10) * (int)xScale, (menuLogo.Height / 10) * (int)yScale);
                    playRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width * (int)xScale / 20) / 2), 250, (menuPlay.Width / 5) / (int)xScale, (menuPlay.Height / 5) / (int)yScale);
                    optiRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOpti.Width * (int)xScale / 20) / 2), 425, (menuOpti.Width / 5) / (int)xScale, (menuOpti.Height / 5) / (int)yScale);
                    quitRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width * (int)xScale / 20) / 2), 575, (menuQuit.Width / 5) / (int)xScale, (menuQuit.Height / 5) / (int)yScale);

                    // The following code makes the play, option, or quit button expand in size and hitbox if you hover over them

                    if (InputManager.MouseHover(mState, playRect))
                    {
                        playRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width * (int)xScale / 20) / 2) - 50, 200, (menuPlay.Width / 4) / (int)xScale, (menuPlay.Height / 4) / (int)yScale);
                    }
                    else if (InputManager.MouseHover(mState, optiRect))
                    {
                        optiRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOpti.Width * (int)xScale / 20) / 2) - 50, 375, (menuOpti.Width / 4) / (int)xScale, (menuOpti.Height / 4) / (int)yScale);
                    }
                    else if (InputManager.MouseHover(mState, quitRect))
                    {
                        quitRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width * (int)xScale / 20) / 2) - 50, 525, (menuQuit.Width / 4) / (int)xScale, (menuQuit.Height / 4) / (int)yScale);
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > playRect.X
                        && mState.X < playRect.X + playRect.Width
                        && mState.Y > playRect.Y
                        && mState.Y < playRect.Y + playRect.Height)
                    {
                        currentGameState = GameState.Game;
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > optiRect.X
                        && mState.X < optiRect.X + optiRect.Width
                        && mState.Y > optiRect.Y
                        && mState.Y < optiRect.Y + optiRect.Height)
                    {
                        currentGameState = GameState.Pause;
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > quitRect.X
                        && mState.X < quitRect.X + quitRect.Width
                        && mState.Y > quitRect.Y
                        && mState.Y < quitRect.Y + quitRect.Height)
                    {
                        this.Exit();
                    }


                    break;
                case GameState.Game:

                    userInterface.Update(mainPlayer.Health, mainPlayer.Ammo); //Updates the UI. Values to be updated later

                    if (InputManager.IsKeyDown(Keys.R)) // A temporary way to instantly lose the game. Or maybe an unintentional feature!!!
                    {
                        currentGameState = GameState.GameOver;
                    }
                    if (InputManager.IsKeyDown(Keys.P)) // A way to pause the game.
                    {
                        currentGameState = GameState.Pause;
                    }

                    // Ends the game when the player's HP falls below one.
                    if (mainPlayer.Health <= 0)
                    {
                        currentGameState = GameState.GameOver;
                    }

                    mainPlayer.Update(gameTime);
                    for (int i = 0; i < mainPlayer.PlayerBullets.Count; i++)
                    {
                        mainPlayer.PlayerBullets[i].Update(gameTime);
                    }
                    break;
                case GameState.Pause:

                    if (InputManager.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Game;
                    }

                    if (InputManager.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }

                    break;
                case GameState.GameOver:

                    if (InputManager.IsKeyDown(Keys.Enter))
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

                    _spriteBatch.Draw(menuLogo, logoRect, Color.White);
                    _spriteBatch.Draw(menuPlay, playRect, Color.White);
                    _spriteBatch.Draw(menuOpti, optiRect, Color.White);
                    _spriteBatch.Draw(menuQuit, quitRect, Color.White);

                    MouseState mState = Mouse.GetState();

                    _spriteBatch.DrawString(font, "Menu", new Vector2(_graphics.PreferredBackBufferWidth - 180, 20), Color.White);

                    //_spriteBatch.DrawString(font, "xScale: " + xScale, new Vector2(_graphics.PreferredBackBufferWidth - 180, 50), Color.White);
                    //_spriteBatch.DrawString(font, "yScale: " + yScale, new Vector2(_graphics.PreferredBackBufferWidth - 180, 80), Color.White);

                    _spriteBatch.DrawString(font, "X: " + mState.X, new Vector2(_graphics.PreferredBackBufferWidth - 180, 110), Color.White);
                    _spriteBatch.DrawString(font, "Y: " + mState.Y, new Vector2(_graphics.PreferredBackBufferWidth - 180, 140), Color.White);

                    //Draws reticle
                    _spriteBatch.Draw(gameReticle, new Rectangle(mState.X - 25, mState.Y - 25, 50, 50), Color.White);

                    break;
                case GameState.Game:
                    MouseState mStateGame = Mouse.GetState();
                    mainPlayer.Draw(_spriteBatch);
                    _spriteBatch.DrawString(font, "Game", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);
                    userInterface.Draw(_spriteBatch); //Draws UI
                    for (int i = 0; i < mainPlayer.PlayerBullets.Count; i++)
                    {
                        mainPlayer.PlayerBullets[i].Draw(_spriteBatch, gameTime);
                    }

                    //Draws reticle
                    _spriteBatch.Draw(gameReticle, new Rectangle(mStateGame.X - 25, mStateGame.Y - 25, 50, 50), Color.White);

                    break;
                case GameState.Pause:

                    _spriteBatch.DrawString(font, "Pause", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);

                    break;
                case GameState.GameOver:

                    _spriteBatch.DrawString(font, "Game Over", new Vector2(_graphics.PreferredBackBufferWidth - 175, 20), Color.White);

                    break;
            }

            _spriteBatch.End();

            //Draw debug logger
            _spriteBatch.Begin();
            DebugLog.Instance.Draw(_spriteBatch,
                _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}