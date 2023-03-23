using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Util;
using System;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// An abstract control that allows for grid traversal
    /// </summary>
    internal abstract class GridControl : MonoGameControl
    {
        /// <summary>
        /// The size of the grid
        /// </summary>
        public virtual float GridSize
        {
            get => gridSize;
            set
            {
                //Make sure it is above 0
                if (value > 0f)
                {
                    gridSize = value;
                }
            }
        }
        private float gridSize;

        /// <summary>
        /// The color of the grid to be drawn to the control
        /// </summary>
        public Color GridColor { get; set; }

        /// <summary>
        /// The input manager as a field (much less to type)
        /// </summary>
        protected InputManager input;


        protected override void Initialize()
        {
            //Shortcut to the input manager
            input = InputManager.Instance;
            GridSize = 100f;
            GridColor = Color.White * 0.5f;

            ////
            base.Initialize();
            ////
            

        }

        /// <summary>
        /// Draws the grid of this control using the grid size property
        /// <para>Note: ShapeBatch should have Begin() already called prior</para>
        /// </summary>
        protected void DrawGrid()
        {
            //Compute the offset to draw the grid
            Vector2 offset = -Editor.Cam.Position/GridSize;//Get offset based on grid size
            offset -= Vector2.Floor(offset);//Get the decimal part only
            offset *= GridSize;//Multiply by grid size to get offset in pixels

            Vector2 edbug = Vector2.Zero;

            //Draw vertical grid lines
            for (float x = offset.X; x < Editor.graphics.Viewport.Width; x += GridSize)
            {
                ShapeBatch.Line(
                    new Vector2(x, 0),
                    new Vector2(x, Editor.graphics.Viewport.Height),
                    GridColor);

                edbug.X++;
            }

            //Draw horizontal grid lines
            for (float y = offset.Y; y < Editor.graphics.Viewport.Height; y += GridSize)
            {
                ShapeBatch.Line(
                    new Vector2(0, y),
                    new Vector2(Editor.graphics.Viewport.Width, y),
                    GridColor);

                edbug.Y++;
            }

            Editor.spriteBatch.Begin();
            Editor.spriteBatch.DrawString(Editor.Font, edbug.ToString(), Vector2.Zero, Color.Red);
            Editor.spriteBatch.DrawString(Editor.Font, Editor.graphics.Viewport.ToString(), Vector2.UnitY*20, Color.Wheat);
            Editor.spriteBatch.DrawString(Editor.Font, offset.ToString(), Vector2.UnitY*40, Color.Green);
            Editor.spriteBatch.End();
        }

        #region Actions


        /// <summary>
        /// Updates the different actions that can be preformed by the user
        /// </summary>
        protected void PreformUserActions()
        {
            //If alt and mouse down or middle click, pan
            if ((input.IsDown(Keys.LeftAlt) && input.IsDown(MouseButtonTypes.Left))
                || input.IsDown(MouseButtonTypes.Middle))
            {
                Pan();
            }

            

            //Zoom based on scrolling
            ZoomEditor(input.GetScrollDirection());

            //If plus, zoom in
            if (input.IsDown(Keys.OemPlus))
            {
                ZoomEditor(1);
            }

            //If plus, zoom out
            if (input.IsDown(Keys.OemMinus))
            {
                ZoomEditor(-1);
            }

            ////
            Editor.Cam.GetTransformation();//Create the transformation for the draw cycle
        }

        /// <summary>
        /// Pans the camera based on the user movement
        /// </summary>
        public virtual void Pan()
        {
            //Set mouse cursor
            Cursor = System.Windows.Forms.Cursors.Hand;
            //Move build in camera by mouse change amount
            //Divide by zoom so that movement is constant
            Editor.Cam.Move(
                (input.PrevMouseState.Position -
                input.CurrentMouseState.Position)
                .ToVector2() / Editor.Cam.Zoom);
        }

        /// <summary>
        /// Zooms by the normalized specified amount within the editor limits
        /// </summary>
        /// <param name="zoom">The zoom amount</param>
        public virtual void ZoomEditor(float zoom)
        {
            //Zoom by adding a multiplied version of the current
            //zoom by a positive or negative 1/15
            //doing this ensures that the scroll is constant
            //Clamp at values too big or small
            Editor.Cam.Zoom = MathHelper.Clamp(
                Editor.Cam.Zoom + Editor.Cam.Zoom * zoom / 10, 0.1f, 3f);
        }

        #endregion
    }
}
