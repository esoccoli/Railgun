using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Objects.Visuals;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// A control that contains tiles of a tileset
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/19/2023
    /// </summary>
    internal class TilePicker : GridControl
    {
        //DEBUG
        public Texture2D testure;

        #region Selection

        /// <summary>
        /// The size of the grid
        /// <para>Note: setting will reset selection rectangle</para>
        /// </summary>
        public override float GridSize
        {
            get => gridSize;
            set
            {
                //Make sure it is above 0
                if (value > 0f)
                {
                    gridSize = value;

                    //Reset selection rectangle
                    selectionRectangle = new Rectangle(0, 0, (int)value, (int)value);

                    CreateTileSelection();
                }
            }
        }

        /// <summary>
        /// The rectangle to show the tile that is currently selected
        /// </summary>
        private Rectangle selectionRectangle;

        /// <summary>
        /// The color to highlight the selection
        /// </summary>
        private Color selectionColor;

        /// <summary>
        /// The outline color of the selection
        /// </summary>
        private Color selectionOutlineColor;

        /// <summary>
        /// Creates a tile from the current selection
        /// </summary>
        private void CreateTileSelection()
        {
            //Create tile from selection
            TileManager.Instance.CurrentTile =
                new Tile(new VisualElement(testure, selectionRectangle),
                true);
        }

        #endregion

        #region Mono Behavior

        protected override void Initialize()
        {
            //Set max and min zoom
            MinZoom = 0.1f;
            MaxZoom = 20f;

            //Set selection rectangle to a default value
            selectionRectangle = new Rectangle(0, 0, (int)GridSize, (int)GridSize);
            selectionColor = Color.White * 0.5f;
            selectionOutlineColor = Color.White;

            ////
            base.Initialize();
            ////

            //Set background color to panel
            Editor.BackgroundColor = new Color(51, 51, 51);

            //Set grid color
            GridColor = Color.White * 0.5f;

            //Load DEBUG texture
            testure = Editor.Content.Load<Texture2D>("tmp/Grass hill tiles v.2");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ////

            PerformUserActions();

            //If inside control
            if(IsMouseInsideControl)
            {
                //If selecting a tile
                if(!panning && input.JustPressed(MouseButtonTypes.Left))
                {
                    //Calculate selection rectangle to fit on grid
                    selectionRectangle = 
                        new Rectangle(
                            MouseGridPosition * new Point((int)GridSize),
                            new Point((int)GridSize));

                    CreateTileSelection();
                }
            }
        }

        protected override void Draw()
        {
            base.Draw();
            ////

            Editor.spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.NonPremultiplied,//Better transparency
                SamplerState.PointClamp,//Perfect Pixelation
                DepthStencilState.Default,
                RasterizerState.CullNone,
                null,//No shaders
                Editor.Cam.Transform);//Transform by camera
            ////
                

            Editor.spriteBatch.Draw(testure, Vector2.Zero, Color.White);

            //Highlight selection
            Editor.spriteBatch.Draw(whitePixel,
                selectionRectangle, selectionColor);

            ////
            Editor.spriteBatch.End();

            //Draw grid and other shapebatch visuals

            //Begin shapebatch without depth (so that shapes are drawn to the top)
            Editor.graphics.DepthStencilState = DepthStencilState.None;
            ShapeBatch.Begin(Editor.graphics);
            ////

            DrawGrid();


            //The grid size relative to the camera's zoom
            float cameraGridSize = GridSize * Editor.Cam.Zoom;

            //Compute selection rectangle based on cam transformation
            ShapeBatch.BoxOutline(
                selectionRectangle.X * Editor.Cam.Zoom + Editor.Cam.Transform.Translation.X,
                selectionRectangle.Y * Editor.Cam.Zoom + Editor.Cam.Transform.Translation.Y,
                cameraGridSize, cameraGridSize, selectionOutlineColor);

            ////
            ShapeBatch.End();
            //Set depth back to default
            Editor.graphics.DepthStencilState = DepthStencilState.Default;
        }

        #endregion
    }
}
