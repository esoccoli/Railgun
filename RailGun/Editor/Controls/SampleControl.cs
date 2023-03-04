using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;

namespace Railgun.Editor.Controls
{
    public class SampleControl : MonoGameControl
    {
        const string WelcomeMessage = "Hello MonoGame.Forms!";

        private Texture2D _testTexture;

        protected override void Initialize()
        {
            base.Initialize();

            _testTexture = Editor.Content.Load<Texture2D>("TestDir/IMG_4658");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            Editor.spriteBatch.DrawString(Editor.Font, WelcomeMessage, new Vector2(
                (Editor.graphics.Viewport.Width / 2) - (Editor.Font.MeasureString(WelcomeMessage).X / 2),
                (Editor.graphics.Viewport.Height / 2) - (Editor.FontHeight / 2)),
                Color.White);

            Editor.spriteBatch.Draw(_testTexture,_testTexture.Bounds, Color.White);

            Editor.spriteBatch.End();
        }
    }
}
