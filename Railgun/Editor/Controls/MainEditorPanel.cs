using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;

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
        private Texture2D _test;
        private SpriteFont _consolas20;
        private Vector2 _changed;

        //Useful information
        public Point PrevMousePosition { get; protected set; }
        /// <summary>
        /// Called every update cycle of this panel
        /// </summary>
        public event UpdateDelegate OnUpdate;

        protected override void Initialize()
        {
            //Initialization



            ////
            base.Initialize();
            ////

            _test = Editor.Content.Load<Texture2D>("test");
            _consolas20 = Editor.Content.Load<SpriteFont>("Consolas20");

        }

        protected override void Update(GameTime gameTime)
        {
            //Input
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();


            //Plan: right click+drag to select, middle or alt+drag to pan, left to place


            //Check if dragging (alt + left or middle
            if(ms.MiddleButton == ButtonState.Pressed ||
                (ks.IsKeyDown(Keys.LeftAlt)&&ms.LeftButton
                == ButtonState.Pressed))
            {
                //Set mouse cursor to hand (using this to not be ambiguous)
                Cursor = System.Windows.Forms.Cursors.Hand;
                //Move build in camera by mouse change amount
                Editor.Cam.Move((PrevMousePosition - ms.Position).ToVector2());
                _changed = (ms.Position - PrevMousePosition).ToVector2();
            }
            else
            {
                //Set mouse cursor to hand (using this to not be ambiguous)
                Cursor = System.Windows.Forms.Cursors.Cross;
            }

            //Set previous info
            PrevMousePosition = ms.Position;

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


            Editor.spriteBatch.Draw(_test,Vector2.Zero,Color.White);




            ////
            Editor.spriteBatch.End();
            
            //Overlayed things to be drawn
            Editor.spriteBatch.Begin();
            ////


            ////
            Editor.spriteBatch.End();
        }
    }
}
