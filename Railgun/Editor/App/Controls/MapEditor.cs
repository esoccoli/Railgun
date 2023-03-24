using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App.Controls
{
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
    internal class MapEditor : GridControl
    {
        //DEBUG
        private Texture2D test;
        private SpriteFont consolas20;

        #region Bigger Managing Classes

        /// <summary>
        /// Called every update cycle of this panel
        /// </summary>
        public event UpdateDelegate OnUpdate;

        /// <summary>
        /// The current map in this editor
        /// </summary>
        public Map CurrentMap { get; set; }

        #endregion

        //If I didn't do this, the designer would try to set a default value
        //before the map is set in initialize
        [System.ComponentModel.Browsable(false)]
        /// <summary>
        /// The map's grid size (always an integer value)
        /// </summary>
        public override float GridSize
        {
            get => CurrentMap.TileSize;
            set
            {
                if(CurrentMap != null)
                    CurrentMap.TileSize = (int)value;
            }
        }

        #region Selector

        /// <summary>
        /// The fill color of the selector
        /// </summary>
        protected Color selectorColorFill;

        /// <summary>
        /// The color of the selector outline
        /// </summary>
        protected Color selectorColorOutline;

        /// <summary>
        /// Holds the point that a selection is started
        /// </summary>
        protected Point selectorPoint;

        /// <summary>
        /// Whether the user is selecting or not
        /// </summary>
        protected bool selecting;

        /// <summary>
        /// The rectangle being selected
        /// </summary>
        protected Rectangle selectionRectangle;

        #endregion

        #region Mono Behavior

        protected override void Initialize()
        {
            //Initialization

            //Setup selector color
            selectorColorFill = new Color(Color.White, 0.2f);
            selectorColorOutline = new Color(Color.White, 0.2f);

            //Start in a new map
            CurrentMap = new Map(128);

            //Set max and min zoom
            MinZoom = 0.1f;
            MaxZoom = 2f;

            ////
            base.Initialize();
            ////

            //Set bg color
            Editor.BackgroundColor = new Color(25, 25, 25);

            test = Editor.Content.Load<Texture2D>("test");
            consolas20 = Editor.Content.Load<SpriteFont>("Consolas20");

            //Set debug log font
            DebugLog.Instance.Font = consolas20;

            //Center camera on the 0,0 coordinate
            Editor.Cam.DefaultPosition = new Vector2(GridSize / 2);

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ////

            //Pan and zoom
            PerformUserActions();

            //If selecting, select
            if(selecting)
            {
                SelectObjects();
            }
            else if(!panning)//If not selecting nor panning, placing
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Arrow;

                //If mouse down
                if (input.IsDown(MouseButtonTypes.Left))
                {
                    Place();
                }
            }

            //Invoke update event
            OnUpdate();
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

            //Draw map
            CurrentMap.Draw(Editor.spriteBatch);

            TileManager.Instance.CurrentTile.Draw(Editor.spriteBatch,
                new Rectangle(
                    MouseGridPosition * new Point(CurrentMap.TileSize),
                    new Point((int)GridSize)));

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

            //Draw grid
            DrawGrid();

            ////
            ShapeBatch.End();
            //Set depth back to default
            Editor.graphics.DepthStencilState = DepthStencilState.Default;

            //Draw DEBUG log
            Editor.spriteBatch.Begin();
            DebugLog.Instance.Draw(Editor.spriteBatch, GraphicsDevice.Viewport);
            Editor.spriteBatch.End();
        }

        #endregion

        #region Actions and Events

        /// <summary>
        /// Called when a button on the mouse is pressed, starts panning and selection
        /// </summary>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //If alt dragging or middle dragging
            if (e.Button == System.Windows.Forms.MouseButtons.Right ||
                (input.IsDown(Keys.LeftShift) &&
                e.Button == System.Windows.Forms.MouseButtons.Left))
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Cross;
                selecting = true;
                //Set initial selection point
                selectorPoint = input.CurrentMouseState.Position;
            }
        }

        /// <summary>
        /// Called when a button on the mouse is released, stops panning and selection
        /// </summary>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            //If alt dragging or middle dragging
            if (e.Button == System.Windows.Forms.MouseButtons.Right ||
                (e.Button == System.Windows.Forms.MouseButtons.Left))
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Arrow;
                //Reset selection
                selectionRectangle = Rectangle.Empty;
                selecting = false;
            }
        }

        /// <summary>
        /// Places the current selected object
        /// </summary>
        public void Place()
        {
            //If placing
            if(input.JustPressed(MouseButtonTypes.Left))
            {
                //Place current tile at tile point
                CurrentMap[CurrentMap.GetGridPoint(
                    MouseCameraPosition)]
                    = TileManager.Instance.CurrentTile;

                //DEBUG log
                DebugLog.Instance.AddPersistantMessage(
                    $"[Tile placed] Mouse: " +
                    $"{CurrentMap.GetGridPoint(MouseCameraPosition)}",
                    Color.Red);
            }
        }
        
        /// <summary>
        /// Updates for selections using the specified mouse button
        /// </summary>
        public void SelectObjects()
        {
            //Set selection rectangle
            selectionRectangle = new Rectangle(
                selectorPoint, input.CurrentMouseState.Position - selectorPoint);
        }

        #endregion

        #region Other Methods EMPTY

        

        

        #endregion

    }
}
