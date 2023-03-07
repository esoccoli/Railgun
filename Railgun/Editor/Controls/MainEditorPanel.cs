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
        private Texture2D _test;
        private SpriteFont _consolas20;
        private Vector2 _changed;

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
        private InputManager _input;

        protected override void Initialize()
        {
            //Initialization

            _input = InputManager.Instance;

            ////
            base.Initialize();
            ////

            _test = Editor.Content.Load<Texture2D>("test");
            _consolas20 = Editor.Content.Load<SpriteFont>("Consolas20");

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
                    if(_input.JustPressed(MouseButtonTypes.Middle)
                        || _input.JustPressed(Keys.LeftAlt))
                    {
                        //Set mouse cursor to hand (using explicit path
                        //to class to not be ambiguous)
                        Cursor = System.Windows.Forms.Cursors.Hand;
                        //Change state
                        _currentState = EditorState.Dragging;
                    }
                    break;
                case EditorState.Dragging:

                    //If middle is down or alt-dragging
                    if(_input.IsDown(MouseButtonTypes.Middle)
                        || _input.IsDown(Keys.LeftAlt) && _input.IsDown(MouseButtonTypes.Left))

                    //Move build in camera by mouse change amount
                    Editor.Cam.Move(
                        (_input.PrevMouseState.Position - 
                        _input.CurrentMouseState.Position)
                        .ToVector2());


                    ////Transition

                    //If middle not down and alt not pressed, switch to something
                    if (!_input.IsDown(MouseButtonTypes.Middle)
                        && !_input.IsDown(Keys.LeftAlt))
                    {
                        //If selecting
                        if(_input.IsDown(MouseButtonTypes.Right))
                        {
                            _currentState = EditorState.Selecting;
                        }
                        else//If not that, then go back to placing
                        {
                            //Set mouse cursor to crosshair
                            Cursor = System.Windows.Forms.Cursors.Cross;
                            //Change state
                            _currentState = EditorState.Placing;
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
