using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Railgun.Editor.Util;


namespace Railgun.Editor.Controls
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
    /// The main control that the editor has allowing most editing functionality.
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/6/2023
    /// </summary>
    public class MainEditorPanel : MonoGameControl
    {
        //DEBUG
        private Texture2D test;
        private SpriteFont consolas20;

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
        /// The color of the selector
        /// </summary>
        private Color selectorColor;

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

        protected override void Initialize()
        {
            //Initialization

            //Shortcut to the input manager
            input = InputManager.Instance;

            //Setup selector color
            selectorColor = new Color(Color.GreenYellow, 0.2f);

            CurrentMode = EditorMode.Placing;

            ////
            base.Initialize();
            ////

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

            //Zoom by adding a multiplied version of the current
            //zoom by a positive or negative 1/15
            //doing this ensures that the scroll is constant
            //Clamp at values too big or small
            Editor.Cam.Zoom = MathHelper.Clamp(
                Editor.Cam.Zoom + Editor.Cam.Zoom*input.GetScrollDirection() / 15, 0.3f, 3f);

            ////
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
                Editor.Cam.GetTransformation());//Transform by camera
            ////


            Editor.spriteBatch.Draw(test,Vector2.Zero,Color.White);

            //Editor.spriteBatch.DrawRectangle

            //Editor.graphics.DrawPrimitives(PrimitiveType.TriangleList, 0, 5);


            ////
            Editor.spriteBatch.End();
            
            //Overlayed things to be drawn
            Editor.spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.NonPremultiplied,//Better transparency
                SamplerState.PointClamp,//Perfect Pixelation
                DepthStencilState.Default,
                RasterizerState.CullNone,
                null,
                null);//No matrix transform
            ////

            //Draw selection rectangle
            if(selecting)
            {
                //Solid rectangle
                Editor.spriteBatch.Draw(whitePixel, selectionRectangle, selectorColor);
            }

            



            ////
            Editor.spriteBatch.End();
        }

        /// <summary>
        /// Places the current selected object
        /// </summary>
        public void Place()
        {

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

    }
}
