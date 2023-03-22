using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// A control that contains tiles of a tileset
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/19/2023
    /// </summary>
    public class TilePicker : MonoGameControl
    {
        /// <summary>
        /// The pixel size of each tile
        /// </summary>
        public int TileSize { get; set; }

        protected override void Initialize()
        {
            base.Initialize();

            //Content Here!
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Update Here!
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            //Draw Here!

            Editor.spriteBatch.End();
        }
    }
}
