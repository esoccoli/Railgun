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
            if (input.IsDown(Keys.LeftShift) || CurrentMode == EditorMode.Selecting)
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
            else if (input.IsDown(MouseButtonTypes.Middle))
            {
                //Set mouse cursor
                Cursor = System.Windows.Forms.Cursors.Hand;
                SelectObjects(MouseButtonTypes.Middle);
            }
            else
            {
                selecting = false;
            }






            ////States of the editor (dragging, placing, selecting)
            //switch(_currentState)
            //{
            //    case EditorState.Placing:



            //        ////Transition

            //        //If middle pressed or alt pressed, switch to dragging
            //        if(input.JustPressed(MouseButtonTypes.Middle)
            //            || input.JustPressed(Keys.LeftAlt))
            //        {
            //            TransitionToDragging();
            //        }
            //        break;
            //    case EditorState.Dragging:

            //        //If middle is down or alt-dragging
            //        if(input.IsDown(MouseButtonTypes.Middle)
            //            || input.IsDown(Keys.LeftAlt) && input.IsDown(MouseButtonTypes.Left))
            //        {
            //            //Move build in camera by mouse change amount
            //            Editor.Cam.Move(
            //                (input.PrevMouseState.Position -
            //                input.CurrentMouseState.Position)
            //                .ToVector2());
            //        }


            //        ////Transition

            //        //If middle not down and alt not pressed, switch to something
            //        if (!input.IsDown(MouseButtonTypes.Middle)
            //            && !input.IsDown(Keys.LeftAlt))
            //        {
            //            //If selecting
            //            if(input.IsDown(MouseButtonTypes.Right))
            //            {
            //                TransitionToSelecting();
            //            }
            //            else//If not that, then go back to placing
            //            {
            //                TransitionToPlacing();
            //            }
            //        }
            //        break;
            //    case EditorState.Selecting:




            //        ////Transition



            //        break;
            //}

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
                null,//No shaders
                null);//No matrix transform
            ////

            if(selecting)
            {
                //DEBGU
                var selectionRect = new Rectangle(selectorPoint,
                    input.CurrentMouseState.Position - selectorPoint);

                //Solid rectangle
                Editor.spriteBatch.Draw(whitePixel, selectionRect, selectorColor);

                //Rectangle outline
                DrawRectangleOutline(selectionRect,10, selectorColor);
            }

            



            ////
            Editor.spriteBatch.End();
        }

        /// <summary>
        /// Draws a rectangle based with the specified bounds and color
        /// </summary>
        /// <param name="rectangle">The rectangle outline to draw</param>
        /// <param name="width">The thickness of the outline</param>
        /// <param name="color">The color to draw the rectangle outline</param>
        private void DrawRectangleOutline(Rectangle rectangle, int width, Color color)
        {
            //Create vertices based on the given rectangle
            VertexPositionColor[] vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(rectangle.Left, rectangle.Top, 0), color),
                new VertexPositionColor(new Vector3(rectangle.Right, rectangle.Top, 0), color),

                new VertexPositionColor(new Vector3(rectangle.Right, rectangle.Top, 0), color),
                new VertexPositionColor(new Vector3(rectangle.Right, rectangle.Bottom, 0), color),

                new VertexPositionColor(new Vector3(rectangle.Right, rectangle.Bottom, 0), color),
                new VertexPositionColor(new Vector3(rectangle.Left, rectangle.Bottom, 0), color),

                new VertexPositionColor(new Vector3(rectangle.Left, rectangle.Bottom, 0), color),
                new VertexPositionColor(new Vector3(rectangle.Left, rectangle.Top, 0), color)
            };

            //Draw to a new basic effect
            BasicEffect basicEffect = new BasicEffect(Editor.graphics);
            basicEffect.VertexColorEnabled = true;
            basicEffect.View = Matrix.CreateLookAt(new Vector3(0, 0, 1), Vector3.Zero, Vector3.Up);
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, Editor.graphics.Viewport.Width, Editor.graphics.Viewport.Height, 0, 0, 1);

            basicEffect.CurrentTechnique.Passes[0].Apply();

            // Draw the rectangle outline using DrawUserPrimitives()
            Editor.graphics.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices, 0, 4);
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
            Editor.Cam.Move(
                (input.PrevMouseState.Position -
                input.CurrentMouseState.Position)
                .ToVector2());
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
            
        }

    }
}
