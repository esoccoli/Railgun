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

        /// <summary>
        /// TRUE if currently panning
        /// </summary>
        protected bool panning;

        /// <summary>
        /// The point that the user started panning at
        /// </summary>
        private System.Drawing.Point panningPoint;


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
            //The grid size relative to the camera's zoom
            float cameraGridSize = GridSize * Editor.Cam.Zoom;

            //Compute the offset to draw the grid

            //Create a new vector that offsets origin from cam transflation
            Vector2 offset = new Vector2(
                Editor.Cam.Transform.Translation.X,
                Editor.Cam.Transform.Translation.Y);
            offset /= cameraGridSize;//Get offset based on grid size
            offset -= Vector2.Floor(offset);//Get the decimal part only
            offset *= cameraGridSize;//Multiply by grid size to get offset in pixels

            //Draw vertical grid lines
            for (float x = offset.X; x < Editor.graphics.Viewport.Width; x += cameraGridSize)
            {
                ShapeBatch.Line(
                    new Vector2(x, 0),
                    new Vector2(x, Editor.graphics.Viewport.Height),
                    GridColor);
            }

            //Draw horizontal grid lines
            for (float y = offset.Y; y < Editor.graphics.Viewport.Height; y += cameraGridSize)
            {
                ShapeBatch.Line(
                    new Vector2(0, y),
                    new Vector2(Editor.graphics.Viewport.Width, y),
                    GridColor);
            }

        }

        #region Actions


        /// <summary>
        /// Updates the different actions that can be preformed by the user
        /// </summary>
        protected void PerformUserActions()
        {
            //If alt and mouse down, pan
            //if (input.IsDown(Keys.LeftAlt))
            //{
            //    //Set mouse cursor
            //    Cursor = System.Windows.Forms.Cursors.Hand;
            //    if(input.IsDown(MouseButtonTypes.Left))
            //    {
            //        Pan();
            //    }
            //}
            //middle click, pan
            if (panning)
            {
                Pan();
            }



            //Zoom based on scrolling
            ZoomEditor(input.GetScrollDirection());

            //If plus, zoom in
            if (input.IsDown(Keys.OemPlus))
            {
                ZoomEditor(0.5f);
            }

            //If plus, zoom out
            if (input.IsDown(Keys.OemMinus))
            {
                ZoomEditor(-0.5f);
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

        #region Action based interactions

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //If alt dragging or middle dragging
            if(e.Button == System.Windows.Forms.MouseButtons.Middle ||
                (input.IsDown(Keys.LeftAlt) && 
                e.Button == System.Windows.Forms.MouseButtons.Left))
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Hand;
                panning = true;
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            //If alt dragging or middle dragging
            if (e.Button == System.Windows.Forms.MouseButtons.Middle ||
                (e.Button == System.Windows.Forms.MouseButtons.Left))
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Arrow;
                panning = false;
            }
        }

        //protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    if (panning)
        //    {
        //        //Move build in camera by mouse change amount
        //        //Divide by zoom so that movement is constant
        //        Editor.Cam.Move(
        //            (input.PrevMouseState.Position -
        //            input.CurrentMouseState.Position)
        //            .ToVector2() / Editor.Cam.Zoom);
        //    }

        //    //if (CamMouseDown)
        //    //{
        //    //    int xDiff = CamFirstMouseDownPosition.X - e.Location.X;
        //    //    int yDiff = CamFirstMouseDownPosition.Y - e.Location.Y;

        //    //    Editor.MoveCam(new Vector2(xDiff, yDiff));

        //    //    CamFirstMouseDownPosition.X = e.Location.X;
        //    //    CamFirstMouseDownPosition.Y = e.Location.Y;
        //    //}
        //}

        #endregion
    }
}
