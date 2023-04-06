using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using SharpDX;

namespace Railgun.Editor.App.Util
{
    /// <summary>
    /// An enumeration representing the different mouse buttons that can be pressed
    /// </summary>
    public enum MouseButtonTypes
    {
        Left,
        Middle,
        Right
    }

    /// <summary>
    /// A singleton class for handling and abstracting user input for ease of use
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/7/2023
    /// </summary>
    public class InputManager
    {
        #region Singleton Design

        /// <summary>
        /// The singleton instance of this InputManager
        /// </summary>
        public static InputManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new InputManager();
                }
                return instance;
            }
        }
        private static InputManager instance;

        #endregion

        /// <summary>
        /// Returns the current mouse state
        /// </summary>
        public MouseState CurrentMouseState { get => Mouse.GetState(); }
        /// <summary>
        /// Returns the current keyboard state
        /// </summary>
        public KeyboardState CurrentKeyboardState { get => Keyboard.GetState(); }
        /// <summary>
        /// The mouse state of the pevious update cycle
        /// </summary>
        public MouseState PrevMouseState { get; private set; }
        /// <summary>
        /// The keyboard state of the pevious update cycle
        /// </summary>
        public KeyboardState PrevKeyboardState { get; private set; }

        /// <summary>
        /// Makes the ability to instantiate this input manager limited
        /// to only this class following the singleton design pattern
        /// </summary>
        private InputManager() { }

        /// <summary>
        /// Updates all input related information.
        /// Called by the update event in the main editor.
        /// </summary>
        public void Update()
        {
            PrevMouseState = Mouse.GetState();
            PrevKeyboardState = Keyboard.GetState();
        }

        /// <summary>
        /// Returns whether the specified key is down
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>TRUE if down</returns>
        public bool IsDown(Keys key) => CurrentKeyboardState.IsKeyDown(key);

        /// <summary>
        /// Returns whether the specified mouse button is down
        /// </summary>
        /// <param name="button">The mouse button to check</param>
        /// <returns>TRUE if down</returns>
        public bool IsDown(MouseButtonTypes button)
        {
            //Check each button case
            switch(button)
            {
                case MouseButtonTypes.Left:
                    return CurrentMouseState.LeftButton == ButtonState.Pressed;
                case MouseButtonTypes.Middle:
                    return CurrentMouseState.MiddleButton == ButtonState.Pressed;
                case MouseButtonTypes.Right:
                    return CurrentMouseState.RightButton == ButtonState.Pressed;
            }
            //Should never get here
            return false;
        }

        /// <summary>
        /// Returns whether the specified key was down the previous cycle
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>TRUE if was down</returns>
        public bool WasDown(Keys key) => PrevKeyboardState.IsKeyDown(key);

        /// <summary>
        /// Returns whether the specified mouse button was down the previous cycle
        /// </summary>
        /// <param name="button">The mouse button to check</param>
        /// <returns>TRUE if was down</returns>
        public bool WasDown(MouseButtonTypes button)
        {
            //Check each button case
            switch (button)
            {
                case MouseButtonTypes.Left:
                    return PrevMouseState.LeftButton == ButtonState.Pressed;
                case MouseButtonTypes.Middle:
                    return PrevMouseState.MiddleButton == ButtonState.Pressed;
                case MouseButtonTypes.Right:
                    return PrevMouseState.RightButton == ButtonState.Pressed;
            }
            //Should never get here
            return false;
        }

        /// <summary>
        /// Checks if a key was pressed this cycle but not last
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>TRUE if just pressed</returns>
        public bool JustPressed(Keys key) 
            => IsDown(key) && !WasDown(key);

        /// <summary>
        /// Checks if a mouse button was just pressed
        /// </summary>
        /// <param name="button">Which mouse button to check</param>
        /// <returns>TRUE if just pressed</returns>
        public bool JustPressed(MouseButtonTypes button)
            => IsDown(button) && !WasDown(button);

        /// <summary>
        /// Returns whether the specified key was just released
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>TRUE if just released</returns>
        public bool JustReleased(Keys key) 
            => !IsDown(key) && WasDown(key);

        /// <summary>
        /// Returns whether the specified mouse button was just released
        /// </summary>
        /// <param name="button">The mouse button to check</param>
        /// <returns>TRUE if just released</returns>
        public bool JustReleased(MouseButtonTypes button)
            => !IsDown(button) && WasDown(button);

        /// <summary>
        /// Returns 1,0,-1 representing the scroll wheel direction
        /// 1 = up,
        /// -1 = down,
        /// 0 = no scrolling,
        /// </summary>
        /// <returns>The direction of scrolling</returns>
        public float GetScrollDirection()
        {
            //Subtract last
            return Math.Sign(
                CurrentMouseState.ScrollWheelValue -
                PrevMouseState.ScrollWheelValue);
        }
    }
}
