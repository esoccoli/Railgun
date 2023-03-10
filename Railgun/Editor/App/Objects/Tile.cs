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
        /// The size of this texture
        /// </summary>
        public int TileSize { get; protected set; }


        /// <summary>
        /// The position of this tile relative to the grid
        /// </summary>
        public Vector2 GridLocation => Map.GetGridPoint(Destination.Location.ToVector2(), TileSize)

        /// <summary>
        /// The destination rectangle of this tile
        /// </summary>
        public Rectangle Destination { get; set; }

        /// <summary>
        /// Creates a new tile with the specified destination and texture
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="texture"></param>
        protected Tile(Rectangle destination, Texture2D texture, int tileSize)
        {
            Destination = destination;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Destination, Color.White);
        }
    }
}
