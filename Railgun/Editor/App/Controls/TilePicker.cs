using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using Railgun.Editor.App.Util;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// A control that contains tiles of a tileset
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/19/2023
    /// </summary>
    public class TilePicker : MonoGameControl
    {
        //DEBUG
        public Texture2D testure;

        /// <summary>
        /// The pixel size of each tile
        /// </summary>
        public int TileSize { get; set; }

        protected override void Initialize()
        {
            

            ////
            base.Initialize();
            ////

            //Set background color to panel
            Editor.BackgroundColor = new Color(51, 51, 51);

            //Load DEBUG texture
            testure = Editor.Content.Load<Texture2D>("tmp/Grass hill tiles v.2");
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

            Editor.spriteBatch.Begin();
            ////
            
            Editor.spriteBatch.Draw(testure, Vector2.Zero, Color.White);

            ////
            Editor.spriteBatch.End();

            //Draw grid

            //Begin shapebatch without depth (so that shapes are drawn to the top)
            Editor.graphics.DepthStencilState = DepthStencilState.None;
            ShapeBatch.Begin(Editor.graphics);
            ////

            //Draw vertical grid lines
            for(int x = 0; x < Editor.graphics.Viewport.Width; x += TileSize)
            {
                ShapeBatch.Line(
                    new Vector2(x, 0),
                    new Vector2(x, Editor.graphics.Viewport.Height),
                    Color.White);
            }

            //Draw horizontal grid lines
            for (int y = 0; y < Editor.graphics.Viewport.Height; y += TileSize)
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
