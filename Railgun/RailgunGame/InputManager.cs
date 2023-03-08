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
        // Tracks the current keyboard  & mouse state
        private static KeyboardState kbState;
        private static MouseState mouseState;
    
        // Tracks the keyboard & mouse state from last frame
        private static KeyboardState prevKbState;
        private static MouseState prevMouseState;
    
        /// <summary>
        /// Initializes the InputManager class
        /// </summary>
        static InputManager()
        {
            // Initializes the current & previous mouse and keyboard states
            kbState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        
            prevKbState = Keyboard.GetState();
            prevMouseState = Mouse.GetState();
        }
    
        /// <summary>
        /// Updates the current and previous keyboard and mouse states at the end of each frame
        /// </summary>
        public static void UpdateInputState()
        {
            prevKbState = kbState;
            prevMouseState = mouseState;

            kbState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        /// <summary>
        /// Determines if the specified key is currently being pressed
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is currently being pressed, false otherwise</returns>
        public static bool IsKeyDown(Keys key) => kbState.IsKeyDown(key);

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
                    isDown = mouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButtons.Right:
                    isDown = mouseState.RightButton == ButtonState.Pressed;
                    break;
            }

            return isDown;
        }

        /// <summary>
        /// Checks if the specified key started being pressed this frame
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is down this frame and was up last frame, false otherwise</returns>
        public static bool IsKeyPressed(Keys key) => kbState.IsKeyDown(key) && prevKbState.IsKeyUp(key);
        
        /// <summary>
        /// Checks if the specified key was released this frame
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is up this frame and was down last frame, false otherwise</returns>
        public static bool IsKeyReleased(Keys key) => kbState.IsKeyUp(key) && prevKbState.IsKeyDown(key);
        
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
                    isPressed = mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released;
                    break;
                case MouseButtons.Right:
                    isPressed = mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released;
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
                    isReleased = mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButtons.Right:
                    isReleased = mouseState.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed;
                    break;
            }

            return isReleased;
        }
    }
}