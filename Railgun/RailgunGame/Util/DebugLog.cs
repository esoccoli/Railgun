using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Util
{
    /// <summary>
    /// A singelton class for logging debug messages every
    /// frame and persistant messages
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/29/2023
    /// </summary>
    internal class DebugLog
    {
        /// <summary>
        /// A class representing a message to be logged
        /// </summary>
        private struct Message
        {
            /// <summary>
            /// The text of this message
            /// </summary>
            public string Text { get; }

            /// <summary>
            /// The color of this message
            /// </summary>
            public Color Color { get; }

            /// <summary>
            /// The time that this message should be cleared
            /// </summary>
            public double ClearTime { get; }

            /// <summary>
            /// Creates a new message with the specified text and color
            /// </summary>
            /// <param name="text">Text of this message</param>
            /// <param name="color">Color of this message</param
            /// <param name="messageDuration">The duration that this message should be displayed in seconds</param>
            public Message(string text, Color color, float messageDuration = 9999f)
            {
                Text = text;
                Color = color;
                //If message duration is invalid, set to 0
                if (messageDuration < 0f)
                {
                    messageDuration = 0f;
                }
                ClearTime = DateTime.Now.TimeOfDay.TotalSeconds + messageDuration;
            }
        }

        #region Singleton Design

        /// <summary>
        /// The instance of this DebugLog
        /// </summary>
        public static DebugLog Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DebugLog();
                }
                return instance;
            }
        }
        private static DebugLog instance;

        /// <summary>
        /// Creates a new debug log
        /// </summary>
        private DebugLog()
        {
            updateMessages = new List<Message>();
            persistantMessages = new List<Message>();
            Spacing = 40f;
            Scale = 1f;
        }

        #endregion


        /// <summary>
        /// The messages of this debug log to be cleared each frame
        /// </summary>
        private readonly List<Message> updateMessages;

        /// <summary>
        /// The messages of this debug log to stay until manually cleared
        /// </summary>
        private readonly List<Message> persistantMessages;

        /// <summary>
        /// The spacing between each message line
        /// </summary>
        public float Spacing { get; set; }

        /// <summary>
        /// The scaling of the messages
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// The font to draw with
        /// </summary>
        public SpriteFont Font { get; set; }

        #region Logging

        /// <summary>
        /// Logs a persistant message for a long time
        /// </summary>
        /// <param name="message">Message text</param>
        public void LogPersistant(string message)
        {
            persistantMessages.Add(new Message(message, Color.White));
        }

        /// <summary>
        /// Logs a persistant message for a long time
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="color">Color of message</param>
        public void LogPersistant(string message, Color color)
        {
            persistantMessages.Add(new Message(message, color));
        }

        /// <summary>
        /// Logs a persistant message to display for the specified duration
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="color">Color of message</param>
        /// <param name="duration">Duration of message</param>
        public void LogPersistant(string message, Color color, float duration)
        {
            persistantMessages.Add(new Message(message, color, duration));
        }

        /// <summary>
        /// Logs a message for just this frame
        /// </summary>
        /// <param name="message">Message text</param>
        public void LogFrame(string message)
        {
            updateMessages.Add(new Message(message, Color.White));
        }

        /// <summary>
        /// Logs a message for just this frame
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="color">Color of this message</param>
        public void LogFrame(string message, Color color)
        {
            updateMessages.Add(new Message(message, color));
        }

        #endregion

        /// <summary>
        /// Draws the log to the specified sprite batch
        /// using the specified viewport as an alignment guide
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw to</param>
        /// <param name="screenHeight">The width of the screen</param>
        /// <param name="screenWidth">The height of the screen</param>
        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            //The starting position
            Vector2 currentPosition = new Vector2(10, 10);

            //Draw all update messages
            foreach (Message message in updateMessages)
            {
                spriteBatch.DrawString(
                    Font, message.Text, currentPosition,
                    message.Color, 0f, Vector2.Zero, Scale,
                    SpriteEffects.None, 0f);
                //Increment position by spacing
                currentPosition.Y += Spacing;
            }

            //Clear current message log to prepare for next frame
            updateMessages.Clear();

            //Set position to top right corner now
            currentPosition = new Vector2(screenWidth - 10, 10);

            //The amount of messages to get rid of (if overflow off screen)
            int messagesToRemove = 0;

            //The specific messages to clear
            List<Message> clearList = new List<Message>();

            //Draw all persistant messages
            foreach (Message message in persistantMessages)
            {
                //Measure string to get size then use to align to the right
                Vector2 origin = Font.MeasureString(message.Text);
                origin.Y = 0;//Still align at top

                //Compute opacity amount for text (less than 2 seconds to clear, fade)
                float opacity =
                    (float)(message.ClearTime * 1000f
                    - DateTime.Now.TimeOfDay.TotalMilliseconds)
                    / 2000f;

                //Draw message to content but fade as it gets older
                spriteBatch.DrawString(
                    Font, message.Text, currentPosition,
                    message.Color * opacity, 0f, origin, Scale,
                    SpriteEffects.None, 0f);
                //Increment position by spacing
                currentPosition.Y += Spacing;

                //Check if going off screen
                if (currentPosition.Y > screenHeight)
                {
                    messagesToRemove++;
                }
                //If current time is greater than the time to clear this message, remove
                else if (DateTime.Now.TimeOfDay.TotalSeconds > message.ClearTime)
                {
                    clearList.Add(message);
                }
            }

            //Remove any messages if need be
            persistantMessages.RemoveRange(0, messagesToRemove);

            //Remove any messages that have been cleared
            foreach (Message message in clearList)
            {
                persistantMessages.Remove(message);
            }
        }

    }
}
