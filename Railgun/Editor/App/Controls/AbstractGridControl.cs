using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Util;
using System;
using System.ComponentModel;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// An abstract control that allows for grid traversal
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 2/22/2023=
    /// </summary>
    public abstract class AbstractGridControl : MonoGameControl
    {
        /// <summary>
        /// A white square used for drawing rectangles
        /// </summary>
        protected Texture2D whitePixel;

        #region Grid Properties and Fields

        /// <summary>
        /// The size of the grid
        /// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        protected float gridSize;

        /// <summary>
        /// The color of the grid to be drawn to the control
        /// </summary>
        public Color GridColor { get; set; }

        /// <summary>
        /// The grid point of the mouse relative to the camera
        /// </summary>
        public Point MouseGridPosition { get; protected set; }

        /// <summary>
        /// The mouse position relative to the camera (where the mouse
        /// is pointing to as if it was transformed by the camera)
        /// </summary>
        public Vector2 MouseCameraPosition { get; protected set; }

        #endregion

        /// <summary>
        /// The input manager as a field (much less to type)
        /// </summary>
        protected InputManager input;

        /// <summary>
        /// The tile manager as a field
        /// </summary>
        protected TileManager tileManager;

        /// <summary>
        /// TRUE if currently panning
        /// </summary>
        protected bool panning;

        /// <summary>
        /// The minimum zoom amount for this control
        /// </summary>
        public float MinZoom
        {
            get => minZoom;
            set
            {
                //Clamp to the normal camra constraints
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                minZoom = value;
            }
        }
        private float minZoom;

        /// <summary>
        /// The maximum zoom amount for this control
        /// </summary>
        public float MaxZoom
        {
            get => maxZoom;
            set
            {
                //Clamp to the normal camra constraints
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                maxZoom = value;
            }
        }
        private float maxZoom;


        protected override void Initialize()
        {
            //Shortcut to singeltons
            input = InputManager.Instance;
            tileManager = TileManager.Instance;

            //Grid properties
            GridSize = 100f;
            GridColor = Color.White * 0.5f;

            ////
            base.Initialize();
            ////

            //Create generic white pixel
            whitePixel = new Texture2D(GraphicsDevice, 1, 1);
            whitePixel.SetData(new Color[] { Color.White });

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ComputeMousePosition();
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

            //Create a new vector that offsets origin from cam translation
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

        /// <summary>
        /// Updates the different actions that can be preformed by the user
        /// </summary>
        protected void PerformUserActions()
        {
            //If panning, pan
            if (panning)
            {
                //Move build in camera by mouse change amount
                //Divide by zoom so that movement is constant
                Editor.Cam.Move(
                    (input.PrevMouseState.Position -
                    input.CurrentMouseState.Position)
                    .ToVector2() / Editor.Cam.Zoom);
            }

            //Only perform if mouse is inside this control
            if(IsMouseInsideControl)
            {
                //Zoom based on scrolling
                ZoomEditor(input.GetScrollDirection());

                //Zoom if minus or plus is pressed
                if (input.IsDown(Keys.OemMinus))
                {
                    ZoomEditor(-0.5f);
                }

                //Zoom if minus or plus is pressed
                if (input.IsDown(Keys.OemPlus))
                {
                    ZoomEditor(0.5f);
                }
            }

            //Create the transformation for the draw cycle
            Editor.Cam.GetTransformation();
        }

        #region Camera Functions

        /// <summary>
        /// Resets the camera to 0,0 with a zoom of 1
        /// </summary>
        public void ResetCamera()
        {
            Editor.Cam.Zoom = 1f;
            Editor.Cam.Position = Editor.Cam.DefaultPosition;
        }

        /// <summary>
        /// Zooms by the normalized specified amount within the editor limits
        /// </summary>
        /// <param name="zoom">The zoom amount</param>
        public virtual void ZoomEditor(float zoom)
        {
            //Zoom by adding a multiplied version of the current
            //zoom by a positive or negative 1/15
            //doing this ensures that the scroll is almost constant
            //Clamp at values too big or small
            Editor.Cam.Zoom = MathHelper.Clamp(
                Editor.Cam.Zoom + Editor.Cam.Zoom * zoom / 10, MinZoom, MaxZoom);
        }

        /// <summary>
        /// Updates the mouse position relative to the camera and to the grid
        /// </summary>
        public void ComputeMousePosition()
        {
            //The mouse pos transformed by the inverse cam matrix
            MouseCameraPosition = 
                ComputePointToCamera(input.CurrentMouseState.Position.ToVector2());

            //Transform absolute mouse position by cam, get grid point of that
            MouseGridPosition = Map.GetGridPoint(MouseCameraPosition, GridSize).ToPoint();
        }

        /// <summary>
        /// Returns the specified absolute point in the camera space
        /// </summary>
        /// <param name="point">Absolute position</param>
        /// <returns>Camera position of point</returns>
        public Vector2 ComputePointToCamera(Vector2 point)
            => Vector2.Transform(point, Matrix.Invert(Editor.Cam.Transform));

        #endregion

        #region Event Based Actions

        /// <summary>
        /// Called when a button on the mouse is pressed, stops panning
        /// </summary>
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

        /// <summary>
        /// Called when a button on the mouse is released, stops panning
        /// </summary>
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

        #endregion
    }
}
