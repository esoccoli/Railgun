using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Objects.Visuals
{
    /// <summary>
    /// Represents anything that can be drawn to the screen
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/10/2023
    /// </summary>
    internal interface IVisual
    {


        /// <summary>
        /// Updates this visual if needed
        /// </summary>
        /// <param name="gameTime">The amount of time since last update cycle</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Draws this visual to the specified sprite batch and position
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw to</param>
        /// <param name="position">The position to draw to</param>
        void Draw(SpriteBatch spriteBatch, Vector2 position);

        /// <summary>
        /// Draws this visual to the specified sprite batch and destination
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw to</param>
        /// <param name="destination">The destination rectangle to draw to</param>
        void Draw(SpriteBatch spriteBatch, Rectangle destination);
    }
}
