using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// A control that contains tiles of a tileset
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/19/2023
    /// </summary>
    public class TilePicker : AbstractGridControl
    {
        /// <summary>
        /// The tileset of this tile picker
        /// </summary>
        private PathedTexture tileSetTexture;

        /// <summary>
        /// Creates a new tile picker with the specified tileset texture
        /// </summary>
        /// <param name="tileSetTextureArg">The texture to generate tiles from</param>
        public TilePicker(PathedTexture tileSetTextureArg)
        {
            //This is why I would rather name it "_tileSetTexture"
            tileSetTexture = tileSetTextureArg;
        }

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
        /// Creates a tile from the current selection and adds it to the tile manager
        /// </summary>
        public void CreateTileSelection()
        {
            //Create tile from selection
            TileManager.Instance.CurrentTile = new Tile(tileSetTexture, selectionRectangle);
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


            //Find the center of the viewport in camera space
            Vector2 viewportCenter = 
                ComputePointToCamera(new Vector2(Width / 2, Height / 2));

            //Find the change in position when clamping to bounds
            Vector2 changeInPosition = viewportCenter - Vector2.Clamp(viewportCenter, Vector2.Zero,
                new Vector2(tileSetTexture.Texture.Width, tileSetTexture.Texture.Height));

            //Move camera in opposite direction of change
            Editor.Cam.Move(-changeInPosition);

        }

        protected override void Draw()
        {
            base.Draw();
            ////

            Editor.spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,//Better transparency
                SamplerState.PointClamp,//Perfect Pixelation
                DepthStencilState.Default,
                RasterizerState.CullNone,
                null,//No shaders
                Editor.Cam.Transform);//Transform by camera
            ////
                

            Editor.spriteBatch.Draw(tileSetTexture.Texture, Vector2.Zero, Color.White);

            //Highlight current selection
            Editor.spriteBatch.Draw(whitePixel,
                selectionRectangle, selectionColor);

            //If inside control
            if(IsMouseInsideControl)
            {
                //Highlight current mouse over
                Editor.spriteBatch.Draw(
                    whitePixel,
                    new Rectangle(
                        MouseGridPosition * new Point((int)GridSize),
                        new Point((int)GridSize)),
                    selectionColor);
            }
            
            ////
            Editor.spriteBatch.End();

            //Draw grid and other shapebatch visuals

            //Begin shapebatch without depth (so that shapes are drawn to the top)
            Editor.graphics.DepthStencilState = DepthStencilState.None;
            Editor.graphics.BlendState = BlendState.NonPremultiplied;//For shapebatch transparency
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
