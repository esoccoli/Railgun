using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// Displays the current tile selected with whatever transformations it has
    /// <para>Author: Jonathan  Jan</para>
    /// Date Created: 3/24/2023
    /// </summary>
    public class CurrentTileDisplay : InvalidationControl
    {
        protected override void Initialize()
        {

            ////
            base.Initialize();
            ////

            //Set background color to panel
            Editor.BackgroundColor = new Color(51, 51, 51);

        }

        /// <summary>
        /// Call outside to update this control just one single time.
        /// For example in your Form1.cs class.
        /// Don't call this to fast - if you need a GameLoop you should use a MonoGameControl instead.
        /// </summary>
        public new void Update()
        {
            Invalidate();
        }

        protected override void Draw()
        {
            base.Draw();
            Editor.spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.NonPremultiplied,//Better transparency
                SamplerState.PointClamp,//Perfect Pixelation
                DepthStencilState.Default,
                RasterizerState.CullNone);
            ////

            //Draw the current tile to fill this control
            TileManager.Instance.CurrentTile.Draw(
                Editor.spriteBatch,
                new Rectangle(0, 0, Width, Height));

            ////
            Editor.spriteBatch.End();
        }
    }
}
