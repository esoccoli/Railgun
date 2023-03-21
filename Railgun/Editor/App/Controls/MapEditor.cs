using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// Represents the states that the user can preform within the editor
    /// </summary>
    public enum EditorMode
    {
        Placing,
        Panning,
        Selecting
    }

    /// <summary>
    /// Represents a delegate that will be invoked every update cycle
    /// </summary>
    public delegate void UpdateDelegate();

    /// <summary>
    /// The main control that the editor has allowing most editing functionality
    /// for the current map
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/6/2023
    /// </summary>
    internal class MapEditor : MonoGameControl
    {
        //DEBUG
        private Texture2D test;
        private SpriteFont consolas20;

        /// <summary>
        /// The input manager as a field (much less to type)
        /// </summary>
        private InputManager input;

        //Textures and colors

        /// <summary>
        /// A white square meant for drawing rectangles
        /// </summary>
        private Texture2D whitePixel;

        //Selector

        /// <summary>
        /// The fill color of the selector
        /// </summary>
        private Color selectorColorFill;

        /// <summary>
        /// The color of the selector outline
        /// </summary>
        private Color selectorColorOutline;

        /// <summary>
        /// Holds the point that a selection is started
        /// </summary>
        private Point selectorPoint;

        /// <summary>
        /// Whether the user is selecting or not
        /// </summary>
        private bool selecting;

        /// <summary>
        /// The rectangle being selected
        /// </summary>
        private Rectangle selectionRectangle;

        /// <summary>
        /// The grid point of the mouse relative to the camera
        /// </summary>
        public Point MouseGridPosition { get; protected set; }

        /// <summary>
        /// The mouse position relative to the camera (where the mouse
        /// is pointing to as if it was transformed by the camera)
        /// </summary>
        public Vector2 MouseCameraPosition { get; protected set; }


        //Bigger managing classes

        /// <summary>
        /// Called every update cycle of this panel
        /// </summary>
        public event UpdateDelegate OnUpdate;

        /// <summary>
        /// The current mode of this editor (how you are interacting with it)
        /// </summary>
        public EditorMode CurrentMode { get; set; }

        /// <summary>
        /// The current map in this editor
        /// </summary>
        public Map CurrentMap { get; set; }

        /// <summary>
        /// The current tile to be placed
        /// </summary>
        public Tile CurrentTile { get; set; }

        protected override void Initialize()
        {
            //Initialization

            //Shortcut to the input manager
            input = InputManager.Instance;

            //Setup selector color
            selectorColorFill = new Color(Color.White, 0.2f);
            selectorColorOutline = new Color(Color.White, 0.2f);

            CurrentMode = EditorMode.Placing;

            //Start in a new map
            CurrentMap = new Map(100);

            ////
            base.Initialize();
            ////

            //Set bg color
            Editor.BackgroundColor = new Color(25, 25, 25);

            test = Editor.Content.Load<Texture2D>("test");
            consolas20 = Editor.Content.Load<SpriteFont>("Consolas20");

            //Create generic white pixel
            whitePixel = new Texture2D(GraphicsDevice, 1, 1);
            whitePixel.SetData(new Color[] { Color.White });


        }

        protected override void Update(GameTime gameTime)
        {
            //Plan: right click+drag to select, middle or alt+drag to pan, left to place

            //Maybe don't do FSM
            //Maybe make method: transition

            //If placing
            if (CurrentMode == EditorMode.Placing)
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Arrow;
                //Check if need move
                if (input.IsDown(MouseButtonTypes.Left))
                {
                    Place();
                }
            }

            //If panning
            if (input.IsDown(Keys.LeftAlt) || CurrentMode == EditorMode.Panning)
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Hand;
                //Check if need move
                if (input.IsDown(MouseButtonTypes.Left))
                {
                    Pan();
                }
            }
            else if(input.IsDown(MouseButtonTypes.Middle))
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Hand;
                Pan();
            }

            //If selecting
            else if (input.IsDown(Keys.LeftShift) || CurrentMode == EditorMode.Selecting)
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Cross;
                //Check if need move
                if (input.IsDown(MouseButtonTypes.Left))
                {
                    SelectObjects(MouseButtonTypes.Left);
                }
                else
                {
                    selecting = false;
                }
            }
            else if (input.IsDown(MouseButtonTypes.Right))
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Cross;
                SelectObjects(MouseButtonTypes.Right);
            }
            else
            {
                selecting = false;
            }

            //Zoom based on scrolling
            ZoomEditor(input.GetScrollDirection());

            //If plus, zoom in
            if(input.IsDown(Keys.OemPlus))
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
            ComputeMousePosition();//Find relative mouse to grid and cam
            OnUpdate();//Invoke update event
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();
            //Things affected by the camera
            Editor.spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.NonPremultiplied,//Better transparency
                SamplerState.PointClamp,//Perfect Pixelation
                DepthStencilState.Default,
                RasterizerState.CullNone,
                null,//No shaders
                Editor.Cam.Transform);//Transform by camera
            ////


            Editor.spriteBatch.Draw(test,Vector2.Zero,Color.White);

            //Editor.spriteBatch.Draw(whitePixel,
            //    new Rectangle(
            //        MouseGridPosition*new Point(CurrentMap.TileSize),
            //        new Point(CurrentMap.TileSize)), Color.White);

            //Editor.graphics.DrawPrimitives(PrimitiveType.TriangleList, 0, 5);


            ////
            Editor.spriteBatch.End();

            //Begin shapebatch without depth (so that shapes are drawn to the top)
            Editor.graphics.DepthStencilState = DepthStencilState.None;
            ShapeBatch.Begin(Editor.graphics);
            ////

            //Draw selection rectangle
            if (selecting)
            {
                //Solid rectangle
                ShapeBatch.Box(selectionRectangle, selectorColorFill);
                //Outline
                ShapeBatch.BoxOutline(selectionRectangle, selectorColorOutline);
            }

            ////
            ShapeBatch.End();
            //Set depth back to default
            Editor.graphics.DepthStencilState = DepthStencilState.Default;

        }

        #region Actions

        /// <summary>
        /// Places the current selected object
        /// </summary>
        public void Place()
        {
            //If placing
            if(input.IsDown(MouseButtonTypes.Left))
            {
                //Place current object
                //Tile tile = CurrentTile.
            }
        }

        /// <summary>
        /// Pans the camera based on the user movement
        /// </summary>
        public void Pan()
        {
            //Move build in camera by mouse change amount
            //Divide by zoom so that movement is constant
            Editor.Cam.Move(
                (input.PrevMouseState.Position -
                input.CurrentMouseState.Position)
                .ToVector2()/ Editor.Cam.Zoom);
        }
        
        /// <summary>
        /// Updates for selections using the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The button to check for</param>
        public void SelectObjects(MouseButtonTypes mouseButton)
        {
            //If not already down, do starting procedures
            if(!input.WasDown(mouseButton))
            {
                //Set initial selection point
                selectorPoint = input.CurrentMouseState.Position;
                selecting = true;
            }

            //Selecting procedures

            //Set selection rectangle
            selectionRectangle = new Rectangle(
                selectorPoint, input.CurrentMouseState.Position - selectorPoint);
        }

        /// <summary>
        /// Zooms by the normalized specified amount within the editor limits
        /// </summary>
        /// <param name="zoom">The zoom amount</param>
        public void ZoomEditor(float zoom)
        {
            //Zoom by adding a multiplied version of the current
            //zoom by a positive or negative 1/15
            //doing this ensures that the scroll is constant
            //Clamp at values too big or small
            Editor.Cam.Zoom = MathHelper.Clamp(
                Editor.Cam.Zoom + Editor.Cam.Zoom * zoom / 10, 0.1f, 3f);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resets the camera to 0,0 with a zoom of 1
        /// </summary>
        public void ResetCamera()
        {
            Editor.Cam.Zoom = 1f;
            //Center to the origin tile
            Editor.Cam.Position = new Vector2(CurrentMap.TileSize/2);
        }

        /// <summary>
        /// Updates the mouse position relative to the camera and to the grid
        /// </summary>
        public void ComputeMousePosition()
        {
            //The mouse pos transformed by the inverse cam matrix
            MouseCameraPosition = Vector2.Transform(
                input.CurrentMouseState.Position.ToVector2(),
                Matrix.Invert(Editor.Cam.Transform));

            //Transform absolute mouse position by cam, get grid point of that
            MouseGridPosition = CurrentMap.GetGridPoint(MouseCameraPosition).ToPoint();
        }

        #endregion

    }
}
