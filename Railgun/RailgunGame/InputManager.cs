using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

// File: InputManager.cs
// Author(s): Ella Soccoli
// Date Created: 3/6/23
// Last Updated: 3/8/23
// Details: Checks keyboard and mouse states and determines whether there is any input
// Restrictions: Must call the UpdateInputState() method at the end of each frame to update the current and previous states

namespace Railgun.RailgunGame
{
    /// <summary>
    /// Stores the mouse buttons that can be used
    /// </summary>
    public enum MouseButtons
    {
        Left,
        Right
    }
    
    /// <summary>
    /// Handles tracking the keyboard and mouse states
    /// and allows other classes to check for and use user input.
    /// Make sure to call the UpdateInputState() method at the end of each frame.
    /// </summary>
    public static class InputManager
    {
        /// <summary>
        /// Tracks the current keyboard state
        /// </summary>
        public static KeyboardState KbState { get; private set; }
        
        /// <summary>
        /// Tracks the current mouse state
        /// </summary>
        public static MouseState MouseState { get; private set; }
        
        /// <summary>
        /// Tracks the keyboard state from the previous frame
        /// </summary>
        public static KeyboardState PrevKbState;
        
        /// <summary>
        /// Tracks the mouse state from the previous frame
        /// </summary>
        public static MouseState PrevMouseState;
    
        /// <summary>
        /// Initializes the InputManager class
        /// </summary>
        static InputManager()
        {
            // Initializes the current & previous mouse and keyboard states
            KbState = Keyboard.GetState();
            MouseState = Mouse.GetState();
        
            PrevKbState = Keyboard.GetState();
            PrevMouseState = Mouse.GetState();
        }
    
        /// <summary>
        /// Updates the current and previous keyboard and mouse states at the end of each frame
        /// </summary>
        public static void UpdateInputState()
        {
            PrevKbState = KbState;
            PrevMouseState = MouseState;

            KbState = Keyboard.GetState();
            MouseState = Mouse.GetState();
        }

        /// <summary>
        /// Determines if the specified key is currently being pressed
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is currently being pressed, false otherwise</returns>
        public static bool IsKeyDown(Keys key) => KbState.IsKeyDown(key);

        /// <summary>
        /// Checks if the specified mouse button is currently pressed
        /// </summary>
        /// <param name="button">Mouse button to check</param>
        /// <returns>True if the button is down, false otherwise</returns>
        public static bool IsButtonDown(MouseButtons button)
        {
            // Temp variable to store the value that will be returned
            // Using this to make the compiler happy about returning outside switch statement
            bool isDown = false;
            
            switch (button)
            {
                case MouseButtons.Left:
                    isDown = MouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButtons.Right:
                    isDown = MouseState.RightButton == ButtonState.Pressed;
                    break;
            }

            return isDown;
        }

        /// <summary>
        /// Checks if the specified key started being pressed this frame
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is down this frame and was up last frame, false otherwise</returns>
        public static bool IsKeyPressed(Keys key) => KbState.IsKeyDown(key) && PrevKbState.IsKeyUp(key);
        
        /// <summary>
        /// Checks if the specified key was released this frame
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is up this frame and was down last frame, false otherwise</returns>
        public static bool IsKeyReleased(Keys key) => KbState.IsKeyUp(key) && PrevKbState.IsKeyDown(key);
        
        /// <summary>
        /// Checks if the specified mouse button changed from released to pressed this frame
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns>True if the button is pressed this frame and was released last frame, false otherwise</returns>
        public static bool MouseButtonPressed(MouseButtons button)
        {
            bool isPressed = false;
            
            switch (button)
            {
                case MouseButtons.Left:
                    isPressed = MouseState.LeftButton == ButtonState.Pressed && PrevMouseState.LeftButton == ButtonState.Released;
                    break;
                case MouseButtons.Right:
                    isPressed = MouseState.RightButton == ButtonState.Pressed && PrevMouseState.RightButton == ButtonState.Released;
                    break;
            }

            return isPressed;
        }
        
        /// <summary>
        /// Checks if the specified mouse button changed from pressed to released this frame
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns>True if the button is released this frame and was pressed last frame, false otherwise</returns>
        public static bool MouseButtonReleased(MouseButtons button)
        {
            bool isReleased = false;

            switch (button)
            {
                case MouseButtons.Left:
                    isReleased = MouseState.LeftButton == ButtonState.Released && PrevMouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButtons.Right:
                    isReleased = MouseState.RightButton == ButtonState.Released && PrevMouseState.RightButton == ButtonState.Pressed;
                    break;
            }

            return isReleased;
        }

        /// <summary>
        /// Checks if a mouse is hovering over a rectangle. Written by Igor
        /// </summary>
        /// <param name="mState">The coordinates of the mouse</param>
        /// <param name="rect">The rectangle area that is being checked</param>
        /// <returns>True if the mouse is hovering over a rectangle area, false otherwise</returns>
        public static bool MouseHover(MouseState mState, Rectangle rect)
        {
            if (mState.X > rect.X && mState.X < rect.X + rect.Width
             && mState.Y > rect.Y && mState.Y < rect.Y + rect.Height)
            {
                return true;
            }

            return false;
        }

    }
}