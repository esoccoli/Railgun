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
    internal class TilePicker : GridControl
    {
        //DEBUG
        public Texture2D testure;

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

            //Only preform these actions if the mouse is inside this control
            if (IsMouseInsideControl)
            {
                PerformUserActions();
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

            ////
            Editor.spriteBatch.End();

            //Draw grid

            //Begin shapebatch without depth (so that shapes are drawn to the top)
            Editor.graphics.DepthStencilState = DepthStencilState.None;
            ShapeBatch.Begin(Editor.graphics);
            ////

            DrawGrid();

            ////
            ShapeBatch.End();
            //Set depth back to default
            Editor.graphics.DepthStencilState = DepthStencilState.Default;


        }
    }
}
