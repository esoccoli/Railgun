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
    /// Represents a visual element similar to a texture but with
    /// more functionality such as the orientation to be drawn at
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/10/2023
    /// </summary>
    internal class VisualElement : IVisual
    {
        /// <summary>
        /// The texture of this visual
        /// </summary>
        public Texture2D Texture {  get; protected set; }

        /// <summary>
        /// The source rectangle of this visual's texture
        /// </summary>
        public Rectangle Source { get; protected set; }

        /// <summary>
        /// The tint of this visual
        /// </summary>
        public Color Tint { get; protected set; }

        /// <summary>
        /// The rotation of this visual
        /// </summary>
        public float Rotation { get; protected set; }

        /// <summary>
        /// The scaling size of this visual
        /// </summary>
        public float Scale { get; protected set; }

        /// <summary>
        /// The sprite effect on this visual (how it is flipped)
        /// </summary>
        public SpriteEffects Flip { get; protected set; }

        /// <summary>
        /// Does nothing
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws this visual to the specified spritebatch and position
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        /// <param name="position">The position to draw to</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(
                Texture, position, Source, Tint,
                Rotation, Vector2.Zero, Scale, Flip, 0f);
        }
    }
}
