using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// An abstract control that allows for grid traversal
    /// </summary>
    public abstract class GridControl : MonoGameControl
    {
        /// <summary>
        /// The size of the grid
        /// </summary>
        public float GridSize
        {
            get { return gridSize; }
            set
            {
                //Make sure it is above 0
                if(value > 0f)
                {

                }
            }
        }
        private float gridSize;

        protected override void Initialize()
        {


            ////
            base.Initialize();
            ////
            

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ////
            

        }

        protected override void Draw()
        {
            base.Draw();
            ////
            
            //Draw grid

            //Begin shapebatch without depth (so that shapes are drawn to the top)
            Editor.graphics.DepthStencilState = DepthStencilState.None;
            ShapeBatch.Begin(Editor.graphics);
            ////

            //Draw vertical grid lines
            for (float x = 0; x < Editor.graphics.Viewport.Width; x += GridSize)
            {
                ShapeBatch.Line(
                    new Vector2(x, 0),
                    new Vector2(x, Editor.graphics.Viewport.Height),
                    Color.White);
            }

            //Draw horizontal grid lines
            for (float y = 0; y < Editor.graphics.Viewport.Height; y += GridSize)
            {
                ShapeBatch.Line(
                    new Vector2(0, y),
                    new Vector2(Editor.graphics.Viewport.Width, y),
                    Color.White);
            }

            ////
            ShapeBatch.End();
            //Set depth back to default
            Editor.graphics.DepthStencilState = DepthStencilState.Default;
        }
    }
}
