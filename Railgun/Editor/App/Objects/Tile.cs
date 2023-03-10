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
        private Texture2D texture;


        /// <summary>
        /// The position of this tile relative to the grid
        /// </summary>
        public Point GridLocation
        {
            get
            {
                Point rawPosition = Destination.Location;
                //Divide by the tile size
                rawPosition /= Destination.Size;
                return Point.Zero;
            }
        }

        /// <summary>
        /// The destination rectangle of this tile
        /// </summary>
        public Rectangle Destination { get; set; }

        /// <summary>
        /// Creates a new tile with the specified destination and texture
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="texture"></param>
        protected Tile(Rectangle destination, Texture2D texture)
        {
            Destination = destination;

        }
    }
}
