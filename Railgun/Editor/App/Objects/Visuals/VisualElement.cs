﻿using Microsoft.Xna.Framework;
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
        /// The texture of this visual.
        /// <para>Note: NULLABLE but can't mark as nullable
        /// since this is an older .NET version</para>
        /// </summary>
        public Texture2D Texture {  get; protected set; }

        /// <summary>
        /// The source rectangle of this visual's texture
        /// </summary>
        public Rectangle? Source { get; protected set; }

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

        #region Constructors

        /// <summary>
        /// Creates a new visual element with all the specified parameters
        /// <para>Note: No parameters will create a blank visual</para>
        /// </summary>
        /// <param name="texture">Texture, NULLABLE</param>
        /// <param name="source">Source rectangle of the texture to be used</param>
        /// <param name="rotation">Rotation</param>
        /// <param name="scale">Scaling size</param>
        /// <param name="flip">Sprite effect for orientation</param>
        public VisualElement(Texture2D texture = null, Rectangle? source = null,
            float rotation = 0f, float scale = 1f, SpriteEffects flip = SpriteEffects.None)
        : this(Color.White, texture, source, rotation, scale, flip) { }

        /// <summary>
        /// Creates a new visual element with all the specified parameters
        /// </summary>
        /// <param name="tint">Tint color</param>
        /// <param name="texture">Texture, NULLABLE</param>
        /// <param name="source">Source rectangle of the texture to be used</param>
        /// <param name="rotation">Rotation</param>
        /// <param name="scale">Scaling size</param>
        /// <param name="flip">Sprite effect for orientation</param>
        public VisualElement(Color tint, Texture2D texture = null, Rectangle? source = null,
            float rotation = 0f, float scale = 1f, SpriteEffects flip = SpriteEffects.None)
        {
            Texture = texture;
            Source = source;
            Tint = tint;
            Rotation = rotation;
            Scale = scale;
            Flip = flip;
        }

        #endregion

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
            //Only draw if not null
            if(Texture != null)
            {
                spriteBatch.Draw(
                Texture, position, Source, Tint,
                Rotation, Vector2.Zero, Scale, Flip, 0f);
            }
        }

        /// <summary>
        /// Draws this visual to the specified spritebatch and destination rectangle
        /// <para>Note: scaling property won't work if using this overload</para>
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        /// <param name="destination">The destination rectangle to draw to</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            //Only draw if not null
            if (Texture != null)
            {
                spriteBatch.Draw(
                Texture, destination, Source, Tint,
                Rotation, Vector2.Zero, Flip, 0f);
            }
        }

        #region Static Prefabs

        /// <summary>
        /// Creates a new empty visual
        /// </summary>
        public static VisualElement Empty => new VisualElement(Color.White);

        #endregion
    }
}
