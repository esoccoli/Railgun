using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Railgun.RailgunGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D backgroundHealthUI;
        private Texture2D foregroundHealthUI;


        private UI userInterface;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //UI Stuff
            backgroundHealthUI = Content.Load<Texture2D>("WhiteHealthSquare");
            foregroundHealthUI = Content.Load<Texture2D>("RedHealthSquare");

            userInterface = new UI(backgroundHealthUI, foregroundHealthUI, false, 100, 100, null, 12, 12); //Creates a UI object. Values to be updated later. Null values need to be replaced (obviously)
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            userInterface.Update(90, 10); //Updates the UI. Values to be updated later
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            userInterface.Draw(_spriteBatch); //Draws UI
            base.Draw(gameTime);
        }
    }
}