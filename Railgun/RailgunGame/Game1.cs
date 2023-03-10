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
            currentGameState = GameState.Menu;
            font = this.Content.Load<SpriteFont>("Mynerve24");

            GameTime gameTime = new GameTime();

            //UI Stuff
            backgroundHealthUI = Content.Load<Texture2D>("WhiteHealthSquare");
            foregroundHealthUI = Content.Load<Texture2D>("RedHealthSquare");

            //Creates a player - update later
            Player mainPlayer = new Player(new Rectangle(0, 0, 0, 0), backgroundHealthUI, gameTime);

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.Menu:

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