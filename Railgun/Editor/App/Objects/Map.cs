using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Objects
{
    /// <summary>
    /// Represents a map of tiles within the editor
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/9/2023
    /// </summary>
    internal class Map
    {
        /// <summary>
        /// The size of a tile within this map
        /// </summary>
        public int TileSize { get; protected set; }

        /// <summary>
        /// The tiles in this map
        /// </summary>
        public List<Tile> Tiles { get; protected set; }

        /// <summary>
        /// The entities in this map
        /// </summary>
        public List<Entity> Entities { get; protected set; }

        /// <summary>
        /// Creates a new map with the specified tile size
        /// </summary>
        /// <param name="tileSize">The width and height of a tile</param>
        public Map(int tileSize)
        {
            TileSize = tileSize;
            Tiles = new List<Tile>();
            Entities = new List<Entity>();
        }

        /// <summary>
        /// Returns the point on this map's grid corresponding to the specified point
        /// </summary>
        /// <param name="rawPoint">The point to convert to grid-point</param>
        /// <returns>The grid point corresponding to the specified point</returns>
        public Point GetGridPoint(Point rawPoint)
        {
            return rawPoint / new Point(TileSize);
        }
    }
}
