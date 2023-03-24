using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Util
{
    /// <summary>
    /// A singelton class for logging debug messages every
    /// frame and persistant messages
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/24/2023
    /// </summary>
    internal class DebugLog
    {
        /// <summary>
        /// A class representing a message to be logged
        /// </summary>
        private class Message
        {
            /// <summary>
            /// The text of this message
            /// </summary>
            public string Text { get; private set; }

            /// <summary>
            /// The color of this message
            /// </summary>
            public Color Color { get; private set; }

            /// <summary>
            /// Creates a new message with the specified text and color
            /// </summary>
            /// <param name="text">Text of this message</param>
            /// <param name="color">Color of this message</param>
            public Message(string text, Color color)
            {
                Text = text;
                Color = color;
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
            MessageSpacing = 40f;
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
        public float MessageSpacing { get; set; }

        /// <summary>
        /// The font to draw with
        /// </summary>
        public SpriteFont Font { get; set; }

        #region Logging

        /// <summary>
        /// Adds the specified message to the persistant
        /// log with a color white (will not clear after a draw cycle)
        /// </summary>
        /// <param name="message">Message text</param>
        public void AddPersistantMessage(string message)
        {
            AddPersistantMessage(message, Color.White);
        }

        /// <summary>
        /// Adds the specified message to the persistant
        /// log (will not clear after a draw cycle)
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="color">Message color</param>
        public void AddPersistantMessage(string message, Color color)
        {
            AddMessageToLog(message, color, persistantMessages);
        }

        /// <summary>
        /// Adds the specified message to the persistant
        /// log with a color white (will not clear after a draw cycle)
        /// </summary>
        /// <param name="message">Message text</param>
        public void AddUpdateMessage(string message)
        {
            AddUpdateMessage(message, Color.White);
        }

        /// <summary>
        /// Adds the specified message to the persistant
        /// log (will not clear after a draw cycle)
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="color">Message color</param>
        public void AddUpdateMessage(string message, Color color)
        {
            AddMessageToLog(message, color, updateMessages);
        }

        /// <summary>
        /// Adds the specified message to the specified log
        /// </summary>
        /// <param name="message">Text</param>
        /// <param name="color">Color</param>
        /// <param name="log">Log to add to</param>
        private void AddMessageToLog(string message, Color color, List<Message> log)
        {
            log.Add(new Message(message, color));
        }

        #endregion

        /// <summary>
        /// Draws the log to the specified sprite batch
        /// using the specified viewport as an alignment guide
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw to</param>
        /// <param name="viewport">The viewport of the control to draw to</param>
        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            //The starting position
            Vector2 currentPosition = new Vector2(10, 10);

            //Draw all update messages
            foreach(Message message in updateMessages)
            {
                spriteBatch.DrawString(Font, message.Text, currentPosition, message.Color);
                //Increment position by spacing
                currentPosition.Y += MessageSpacing;
            }

            //Clear current message log to prepare for next frame
            updateMessages.Clear();

            //Set position to top right corner now
            currentPosition = new Vector2(viewport.Width - 10, 10);

            //The amount of messages to get rid of (if overflow off screen)
            int messagesToRemove = 0;

            //Draw all persistant messages
            foreach (Message message in persistantMessages)
            {
                //Measure string to get size then use to align to the right
                Vector2 origin = Font.MeasureString(message.Text);
                origin.Y = 0;//Still align at top

                spriteBatch.DrawString(
                    Font, message.Text, currentPosition,
                    message.Color, 0f, origin, 1f,
                    SpriteEffects.None, 0f);
                //Increment position by spacing
                currentPosition.Y += MessageSpacing;

                //Check if going off screen
                if(currentPosition.Y > viewport.Height)
                {
                    messagesToRemove++;
                }
            }

            //Remove any messages if need be
            persistantMessages.RemoveRange(0, messagesToRemove);
        }

    }
}
