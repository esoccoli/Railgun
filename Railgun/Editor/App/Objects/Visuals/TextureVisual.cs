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
    internal struct TextureVisual// : IVisual
    {
        /// <summary>
        /// The path to the texture of this visual
        /// </summary>
        public string TexturePath { get; }

        /// <summary>
        /// The texture of this visual.
        /// </summary>
        public Texture2D Texture { get; }

        /// <summary>
        /// The source rectangle of this visual's texture
        /// </summary>
        public Rectangle? Source { get; }

        /// <summary>
        /// The tint of this visual
        /// </summary>
        public Color Tint { get; }

        /// <summary>
        /// The rotation of this visual
        /// </summary>
        public float Rotation { get; }

        /// <summary>
        /// The scaling size of this visual
        /// </summary>
        public float Scale { get; }

        /// <summary>
        /// The sprite effect on this visual (how it is flipped)
        /// </summary>
        public SpriteEffects Flip { get; }

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
        public TextureVisual(Texture2D texture = null, Rectangle? source = null,
            float rotation = 0f, float scale = 1f, SpriteEffects flip = SpriteEffects.None)
        : this(Color.White, texture, source, rotation, scale, flip) { }

        /// <summary>
        /// Creates a new visual element with all the specified parameters
        /// </summary>
        /// <param name="tint">Tint color</param>
        /// <param name="texture">Texture, NULLABLE</param>
        /// <param name="source">Source rectangle of the texture to be used</param>
        /// <param name="rotation">Rotation in radians</param>
        /// <param name="scale">Scaling size</param>
        /// <param name="flip">Sprite effect for orientation</param>
        public TextureVisual(Color tint, Texture2D texture = null, Rectangle? source = null,
            float rotation = 0f, float scale = 1f, SpriteEffects flip = SpriteEffects.None)
        {
            Texture = texture;
            Source = source;
            Tint = tint;
            Rotation = MathHelper.WrapAngle(rotation);//Ensure rotation is within normal range
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
        /// Draws this visual to the specified spritebatch and destination rectangle
        /// <para>Note: scaling property won't work if using this overload</para>
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        /// <param name="destination">The destination rectangle to draw to</param>
        /// <param name="opacity">The opacity of the tint using multiplied color</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle destination, float opacity = 1f)
        {
            //Only draw if not null
            if (Texture != null)
            {
                //Offset destination by center of texture for origin to be at center of tile
                destination.Location = destination.Center;

                //Create origin from source rectangle size
                Vector2 origin = Source.Value.Size.ToVector2() / 2f;

                spriteBatch.Draw(
                Texture, destination, Source, Tint * opacity,
                Rotation, origin, Flip, 0f);
            }
        }


        #region Static Prefabs

        /// <summary>
        /// Creates a new empty visual
        /// </summary>
        public static TextureVisual Empty => new TextureVisual(Color.White);

        #endregion
    }
}
