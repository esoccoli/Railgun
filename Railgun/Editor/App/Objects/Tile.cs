using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Objects
{
    /// <summary>
    /// Represents a tile in the game
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/9/2023
    /// </summary>
    internal class Tile
    {
        /// <summary>
        /// The texture of this tile
        /// </summary>
        public Texture2D Texture { get; protected set; }

        /// <summary>
        /// The sprite effect (rotation and flip) of this tile
        /// </summary>
        public SpriteEffects Flip { get; protected set; }

        /// <summary>
        /// The destination rectangle of this tile
        /// </summary>
        public Rectangle Destination { get; set; }

        /// <summary>
        /// The size of this texture
        /// </summary>
        public int TileSize { get; protected set; }

        /// <summary>
        /// The position of this tile relative to the grid
        /// </summary>
        public Vector2 GridLocation
            => Map.GetGridPoint(Destination.Location.ToVector2(), TileSize);

        /// <summary>
        /// Creates a new tile with the specified destination and texture
        /// </summary>
        /// <param name="destination">The destination rectangle to draw this tile to</param>
        /// <param name="texture">The texture of this tile</param>
        /// <param name="orientation">The sprite effect of this tile</param>
        /// <param name="tileSize">The tile's size</param>
        protected Tile(Rectangle destination, Texture2D texture, SpriteEffects orientation, int tileSize)
        {
            Destination = destination;
            Texture = texture;
            TileSize = tileSize;
            Flip = orientation;
        }

        /// <summary>
        /// Draws the tile to the specified sprite batch
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw to</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Destination, null, Color.White, 0f, Vector2.Zero, Flip, 0f);
        }

        /// <summary>
        /// Returns a shallow copy of this tile (not a reference)
        /// </summary>
        /// <returns>A new Tile with the same parameters as this</returns>
        public Tile Clone()
        {
            return new Tile(Destination, Texture, Flip, TileSize);
        }
    }
}
