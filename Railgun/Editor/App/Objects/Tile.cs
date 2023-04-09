using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Objects
{
    /// <summary>
    /// Represents the visual element of a tile similar to a texture but with
    /// more functionality such as the orientation to be drawn at
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/10/2023
    /// </summary>
    public struct Tile
    {
        /// <summary>
        /// The pathed texture of this visual
        /// </summary>
        public PathedTexture? Texture { get; }

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
        /// The sprite effect on this visual (how it is flipped)
        /// </summary>
        public SpriteEffects SpriteEffect { get; }

        #region Constructors

        /// <summary>
        /// Creates a new visual element with all the specified parameters
        /// <para>Note: No parameters will create a blank visual</para>
        /// </summary>
        /// <param name="texture">Texture</param>
        /// <param name="source">Source rectangle of the texture to be used</param>
        /// <param name="rotation">Rotation</param>
        /// <param name="flip">Sprite effect for orientation</param>
        public Tile(PathedTexture? texture = null, Rectangle? source = null,
            float rotation = 0f, SpriteEffects flip = SpriteEffects.None)
        : this(Color.White, texture, source, rotation, flip) { }

        /// <summary>
        /// Creates a new visual element with all the specified parameters
        /// </summary>
        /// <param name="tint">Tint color</param>
        /// <param name="texture">Texture</param>
        /// <param name="source">Source rectangle of the texture to be used</param>
        /// <param name="rotation">Rotation in radians</param>
        /// <param name="flip">Sprite effect for orientation</param>
        public Tile(Color tint, PathedTexture? texture = null, Rectangle? source = null,
            float rotation = 0f, SpriteEffects flip = SpriteEffects.None)
        {
            Texture = texture;
            Source = source;
            Tint = tint;
            Rotation = MathHelper.WrapAngle(rotation);//Ensure rotation is within normal range
            SpriteEffect = flip;
        }

        #endregion

        /// <summary>
        /// Draws this visual to the specified spritebatch and destination rectangle
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

                Vector2 origin = Texture.Value.Texture.Bounds.Size.ToVector2() / 2f;

                //If source is specified, create origin from source rectangle size
                if (Source != null)
                    origin = Source.Value.Size.ToVector2() / 2f;


                spriteBatch.Draw(
                Texture.Value.Texture, destination, Source, Tint * opacity,
                Rotation, origin, SpriteEffect, 0f);
            }
        }

        #region Cloning Methods

        /// <summary>
        /// Returns this tile rotated clockwise 90 degrees by the
        /// specified amount of times
        /// </summary>
        /// <param name="amount">Amount of times to rotate the tile 90 cw by</param>
        /// <returns>The rotated tile</returns>
        public Tile Rotate(int amount)
            => new Tile(Tint, Texture, Source,
                Rotation + MathHelper.PiOver2 * amount, SpriteEffect);

        /// <summary>
        /// Returns this tile flipped horizontally relative to the current
        /// flip orientation
        /// </summary>
        /// <returns></returns>
        public Tile FlipHorizontally()
        {
            //Effect to apply
            SpriteEffects effect = SpriteEffects.FlipHorizontally;
            float rotation = 0f;

            //Check if already flipped
            switch (SpriteEffect)
            {
                //If already horizontal, double flipped is none
                case SpriteEffects.FlipHorizontally:
                    effect = SpriteEffects.None;
                    break;
                //If vertical, it will cancel out with horizontal, so flip 180 deg
                case SpriteEffects.FlipVertically:
                    effect = SpriteEffects.None;
                    rotation = MathHelper.Pi;
                    break;
            }

            //Return flipped tile
            return new Tile(Tint, Texture, Source, Rotation + rotation, effect);
        }

        /// <summary>
        /// Returns this tile flipped vertically relative to the current
        /// flip orientation
        /// </summary>
        /// <returns></returns>
        public Tile FlipVertically()
        {
            //Effect to apply
            SpriteEffects effect = SpriteEffects.FlipVertically;
            float rotation = 0f;

            //Check if already flipped
            switch (SpriteEffect)
            {
                //If already vertical, double flipped is none
                case SpriteEffects.FlipVertically:
                    effect = SpriteEffects.None;
                    break;
                //If horizontal, it will cancel out with vertical, so flip 180 deg
                case SpriteEffects.FlipHorizontally:
                    effect = SpriteEffects.None;
                    rotation = MathHelper.Pi;
                    break;
            }

            //Return flipped tile
            return new Tile(Tint, Texture, Source, Rotation + rotation, effect);
        }

        #endregion

        #region Static Prefabs

        /// <summary>
        /// Creates a new empty visual
        /// </summary>
        public static Tile Empty => new Tile(Color.White);

        #endregion
    }
}
