using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// The main control that the editor has allowing most editing functionality
    /// for the current map
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/6/2023
    /// </summary>
    internal class MapEditor : GridControl
    {
        //DEBUG font
        private SpriteFont consolas20;

        /// <summary>
        /// Called every update cycle of this panel
        /// </summary>
        public event GenericDelegate OnUpdate;

        /// <summary>
        /// The current map in this editor
        /// </summary>
        public Map CurrentMap { get; set; }

        /// <summary>
        /// The map's grid size (always an integer value). Invisible to the designer
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float GridSize
        {
            get => CurrentMap.TileSize;

            set => CurrentMap.TileSize = (int)value;
        }

        /// <summary>
        /// Whether the user is placing or not
        /// </summary>
        private bool placing;

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
            CurrentMap.Layers.Add(new Dictionary<Vector2, Tile>());

            //Set max and min zoom
            MinZoom = 0.1f;
            MaxZoom = 2f;

            ////
            base.Initialize();
            ////

            //Add all edit events
            tileManager.OnRotateCW += RotateCW;
            tileManager.OnRotateCCW += RotateCCW;
            tileManager.OnFlipHorizontal += FlipHorizontal;
            tileManager.OnFlipVertical += FlipVertical;
            tileManager.OnMoveUp += MoveUp;
            tileManager.OnMoveDown += MoveDown;
            tileManager.OnMoveLeft += MoveLeft;
            tileManager.OnMoveRight += MoveRight;

            //Set bg color
            Editor.BackgroundColor = new Color(25, 25, 25);

            consolas20 = Editor.Content.Load<SpriteFont>("Consolas20");

            //Setup debug log
            DebugLog.Instance.Spacing = 25f;
            DebugLog.Instance.Scale = 0.8f;
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

            //Check edit keybinds (rotation, move, flip)
            CheckEditKeys();

            //If selecting, select
            if(selecting)
            {
                SelectObjects();
            }
            else if(!panning)//If not selecting nor panning, placing
            {
                //Only perform if mouse is inside this control
                if(IsMouseInsideControl)
                {
                    //Set mouse cursor
                    Cursor = System.Windows.Forms.Cursors.Arrow;

                    //Placing
                    if(placing)
                    {
                        Place();
                    }
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
                BlendState.AlphaBlend,//Better transparency
                SamplerState.PointClamp,//Perfect Pixelation
                DepthStencilState.Default,
                RasterizerState.CullNone,
                null,//No shaders
                Editor.Cam.Transform);//Transform by camera
            ////

            //Draw map
            CurrentMap.Draw(Editor.spriteBatch);

            //Only show if mouse is inside this control and not selecting
            if(IsMouseInsideControl && !selecting)
            {
                //Draw transparent tile preview
                tileManager.CurrentTile.Draw(
                    Editor.spriteBatch,
                    new Rectangle(
                        MouseGridPosition * new Point(CurrentMap.TileSize),
                        new Point((int)GridSize)),
                    0.5f);
            }

            ////
            Editor.spriteBatch.End();

            //Begin shapebatch without depth (so that shapes are drawn to the top)
            Editor.graphics.DepthStencilState = DepthStencilState.None;
            Editor.graphics.BlendState = BlendState.NonPremultiplied;//For shapebatch transparency
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

            //If not panning or selecting
            if(!panning && !selecting)
            {
                placing = true;
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
                //Stop placing
                placing = false;
            }
        }

        /// <summary>
        /// Places the current selected object
        /// </summary>
        private void Place()
        {
            //If placing
            if(input.IsDown(MouseButtonTypes.Left))
            {
                

                //Place current tile at tile point
                CurrentMap[CurrentMap.GetGridPoint(
                    MouseCameraPosition)]
                    = tileManager.CurrentTile;

                //Set to modified
                FileManager.Modified = true;
            }
        }

        /// <summary>
        /// Updates for selections using the specified mouse button
        /// </summary>
        private void SelectObjects()
        {
            //Set selection rectangle
            selectionRectangle = new Rectangle(
                selectorPoint, input.CurrentMouseState.Position - selectorPoint);
        }

        /// <summary>
        /// Preforms any actions needed for editing a tile such as rotation or flipping
        /// </summary>
        private void CheckEditKeys()
        {
            //Don't preform if alt is down
            if(!input.IsDown(Keys.LeftAlt))
            {
                if (input.JustPressed(Keys.E)) tileManager.RotateCW();
                if (input.JustPressed(Keys.Q)) tileManager.RotateCCW();
            }
        }

        #endregion

        #region Edit

        /// <summary>
        /// Rotates the current tile 90 degrees clockwise OR
        /// rotates the current selection by 90 degrees clockwise
        /// </summary>
        private void RotateCW()
        {
            tileManager.CurrentTile = 
                tileManager.CurrentTile.Rotate(1);
        }

        /// <summary>
        /// Rotates the current tile 90 degrees counter-clockwise OR
        /// rotates the current selection by 90 degrees counter-clockwise
        /// </summary>
        private void RotateCCW()
        {
            tileManager.CurrentTile = 
                tileManager.CurrentTile.Rotate(-1);
        }

        /// <summary>
        /// Flips based on current rotation context of tile
        /// Flips the current tile horizontally OR
        /// Flips the current selection horizontally
        /// </summary>
        private void FlipHorizontal()
        {
            //If not normal rotation or 180 deg rotation, flip vertical instead
            if (tileManager.CurrentTile.Rotation == MathHelper.Pi 
                || tileManager.CurrentTile.Rotation == 0)
            {
                tileManager.CurrentTile = tileManager.CurrentTile.FlipHorizontally();
                return;
            }

            //If it gets here, flip vertical
            tileManager.CurrentTile = tileManager.CurrentTile.FlipVertically();
        }


        /// <summary>
        /// Flips based on current rotation context of tile
        /// Flips the current tile vertically OR
        /// Flips the current selection vertically
        /// </summary>
        private void FlipVertical()
        {
            //If not normal rotation or 180 deg rotation, flip horizontal instead
            if (tileManager.CurrentTile.Rotation == MathHelper.Pi
                || tileManager.CurrentTile.Rotation == 0)
            {
                tileManager.CurrentTile = tileManager.CurrentTile.FlipVertically();
                return;
            }

            //If it gets here, flip vertical
            tileManager.CurrentTile = tileManager.CurrentTile.FlipHorizontally();
        }


        /// <summary>
        /// Moves the current tile up OR
        /// Moves the current selection up
        /// </summary>
        private void MoveUp()
        {

        }

        /// <summary>
        /// Moves the current tile down OR
        /// Moves the current selection down
        /// </summary>
        private void MoveDown()
        {

        }

        /// <summary>
        /// Moves the current tile left OR
        /// Moves the current selection left
        /// </summary>
        private void MoveLeft()
        {

        }

        /// <summary>
        /// Moves the current tile right OR
        /// Moves the current selection right
        /// </summary>
        private void MoveRight()
        {

        }

        #endregion
    }
}
