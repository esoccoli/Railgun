﻿using Microsoft.Xna.Framework;
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
            Editor.spriteBatch.Begin(
                blendState: BlendState.AlphaBlend,//Better transparency
                samplerState: SamplerState.PointClamp);//Perfect Pixelation
            ////

            //Store the viewport
            Rectangle viewRectangle = new Rectangle(1, 1, Width - 1, Height - 1);

            //Draw the current tile to fill this control
            TileManager.Instance.CurrentTile.Draw(Editor.spriteBatch, viewRectangle);

            ////
            Editor.spriteBatch.End();

            //Draw hitbox if on and visable
            if (TileManager.Instance.IsPlacingHitbox)
            {
                //If hitboxes are not visible, make it more transparent
                Color color = Color.Red;
                if(!TileManager.Instance.ViewHitboxes)
                    color *= 0.3f;

                //Begin shapebatch without depth (so that shapes are drawn to the top)
                Editor.graphics.DepthStencilState = DepthStencilState.None;
                //Begin
                ShapeBatch.Begin(Editor.graphics);
                //Draw box of bounds
                ShapeBatch.BoxOutline(viewRectangle, color);
                //Draw x in the middle
                ShapeBatch.Line(Vector2.Zero, new Vector2(Width, Height), 2f, color);
                ShapeBatch.Line(new Vector2(Width, 0f), new Vector2(0f, Height), 2f, color);
                ShapeBatch.End();
            }
        }
    }
}
