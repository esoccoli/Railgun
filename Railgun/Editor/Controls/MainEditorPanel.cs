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
    public enum EditorState
    {
        Placing,
        Dragging,
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
        /// The current state of this editor (how you are interacting with it)
        /// </summary>
        private EditorState _currentState;

        /// <summary>
        /// The input manager as a field (much less to type)
        /// </summary>
        private InputManager input;

        //Textures and colors

        /// <summary>
        /// A white square meant for drawing rectangles
        /// </summary>
        private Texture2D whitePixel;

        /// <summary>
        /// The color of the selector
        /// </summary>
        private Color selectorColor;

        //Numbers and structs

        /// <summary>
        /// Holds the point that a selection is started
        /// </summary>
        private Vector2 selectorPoint;

        protected override void Initialize()
        {
            //Initialization

            //Shortcut to the input manager
            input = InputManager.Instance;

            //Setup selector color
            selectorColor = new Color(Color.GreenYellow, 0.2f);

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

            //States of the editor (dragging, placing, selecting)
            switch(_currentState)
            {
                case EditorState.Placing:



                    ////Transition
                    
                    //If middle pressed or alt pressed, switch to dragging
                    if(input.JustPressed(MouseButtonTypes.Middle)
                        || input.JustPressed(Keys.LeftAlt))
                    {
                        TransitionToDragging();
                    }
                    break;
                case EditorState.Dragging:

                    //If middle is down or alt-dragging
                    if(input.IsDown(MouseButtonTypes.Middle)
                        || input.IsDown(Keys.LeftAlt) && input.IsDown(MouseButtonTypes.Left))
                    {
                        //Move build in camera by mouse change amount
                        Editor.Cam.Move(
                            (input.PrevMouseState.Position -
                            input.CurrentMouseState.Position)
                            .ToVector2());
                    }


                    ////Transition

                    //If middle not down and alt not pressed, switch to something
                    if (!input.IsDown(MouseButtonTypes.Middle)
                        && !input.IsDown(Keys.LeftAlt))
                    {
                        //If selecting
                        if(input.IsDown(MouseButtonTypes.Right))
                        {
                            TransitionToSelecting();
                        }
                        else//If not that, then go back to placing
                        {
                            TransitionToPlacing();
                        }
                    }
                    break;
                case EditorState.Selecting:




                    ////Transition



                    break;
            }

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

            //Solid rectangle
            Editor.spriteBatch.Draw(whitePixel, new Rectangle(
                new Point(10, 10),
                input.CurrentMouseState.Position), selectorColor);

            //Rectangle outline
            DrawRectangleOutline(new Rectangle(
                new Point(10, 10),
                input.CurrentMouseState.Position),
                10, selectorColor);

            



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
        /// A method that transitions to the placing state
        /// </summary>
        private void TransitionToPlacing()
        {
            //Set mouse cursor to crosshair (using explicit path
            //to class to not be ambiguous)
            Cursor = System.Windows.Forms.Cursors.Cross;
            //Change state
            _currentState = EditorState.Placing;
        }

        /// <summary>
        /// A method that transitions to the drag state
        /// </summary>
        private void TransitionToDragging()
        {
            //Set mouse cursor to hand
            Cursor = System.Windows.Forms.Cursors.Hand;
            //Change state
            _currentState = EditorState.Dragging;
        }

        /// <summary>
        /// A method that transitions to the selecting state
        /// </summary>
        private void TransitionToSelecting()
        {
            //Set mouse cursor to selecting
            Cursor = System.Windows.Forms.Cursors.Arrow;
            //Change state
            _currentState = EditorState.Selecting;
        }
    }
}
