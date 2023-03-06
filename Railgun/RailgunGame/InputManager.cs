using Microsoft.Xna.Framework.Input;

namespace Railgun.RailgunGame
{
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
        /// Determines if the specified key is currently not pressed
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is currently not pressed</returns>
        public static bool IsKeyUp(Keys key) => kbState.IsKeyUp(key);
    
        //public static bool IsButtonPressed

    }
}