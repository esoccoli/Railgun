using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Util;
using SharpDX.Direct3D9;
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
        /// The map grid size
        /// </summary>
        public int TileSize
        {
            get => tileSize;
            set
            {
                //Only if valid size
                if(value > 0)
                {
                    tileSize = value;
                }
            }
        }
        private int tileSize;

        /// <summary>
        /// A list of tilemaps where each list is a layer. Tilemaps are dictionaries
        /// where the key is the point on the map and the value is the tile at that point
        /// <para>Note: layers with larger indecies will appear above layers
        /// with smaller indecies</para>
        /// </summary>
        public List<Dictionary<Vector2, Tile>> Layers { get; protected set; }

        /// <summary>
        /// The hitboxes of each tile in this map
        /// </summary>
        public Dictionary<Vector2, bool> Hitboxes { get; protected set; }

        /// <summary>
        /// The tile at the specified grid position and layer
        /// </summary>
        /// <param name="gridPosition">The position relative to the grid</param>
        /// <param name="layer">The drawing layer</param>
        /// <returns>The tile at this position</returns>
        public Tile this[Vector2 gridPosition, int layer = 0]
        {
            get => Layers[layer][gridPosition];
            set => Layers[layer][gridPosition] = value;
        }

        /// <summary>
        /// Creates a new map with the specified tile size
        /// </summary>
        /// <param name="tileSize">The width and height of a tile</param>
        public Map(int tileSize)
        {
            TileSize = tileSize;
            Layers = new List<Dictionary<Vector2, Tile>>();
            Hitboxes = new Dictionary<Vector2, bool>();
        }

        #region Drawing

        /// <summary>
        /// Draws this map's tiles to the specified sprite batch
        /// </summary>
        /// <param name="spriteBatch">THe sprite batch to draw to</param>
        public void DrawTiles(SpriteBatch spriteBatch)
        {
            //Draw each layer
            foreach(Dictionary<Vector2, Tile> layer in Layers)
            {
                //Draw each tile in this layer
                foreach(KeyValuePair<Vector2, Tile> tile in layer)
                {
                    //Draw the tile to rectangle corresponding to its grid location
                    tile.Value.Draw(
                        spriteBatch, new Rectangle(
                            (tile.Key * TileSize).ToPoint(),
                            new Point(TileSize)));

                    ////DEBUG
                    //DebugLog.Instance.AddUpdateMessage(tile.Key.ToString());
                }
            }
        }

        /// <summary>
        /// Draws this map's hitboxes to the shapebatch.
        /// <para>Note: requires shape batch to be started before being called</para>
        /// </summary>
        /// <param name="cameraOffset">The camera offset to account for</param>
        /// <param name="cameraZoom">The camera zoom to account for</param>
        public void DrawHitboxes(Vector2 cameraOffset, float cameraZoom)
        {
            //Define constants for every hitbox
            Vector2 sizeVector = new Vector2(TileSize * cameraZoom);

            foreach (KeyValuePair<Vector2, bool> hitbox in Hitboxes)
            {
                //If hitbox placed
                if(hitbox.Value)
                {
                    //Compute position to draw
                    Vector2 topLeftCorner = hitbox.Key * sizeVector + cameraOffset;
                    Vector2 bottomRightCorner = topLeftCorner + sizeVector;

                    //Draw box of bounds
                    ShapeBatch.BoxOutline(
                        new Rectangle(
                            topLeftCorner.ToPoint(),
                            sizeVector.ToPoint()), Color.Red);
                    //Draw x in the middle
                    ShapeBatch.Line(topLeftCorner, bottomRightCorner, 2f, Color.Red);
                    ShapeBatch.Line(
                        new Vector2(topLeftCorner.X, bottomRightCorner.Y),
                        new Vector2(bottomRightCorner.X, topLeftCorner.Y), 2f, Color.Red);
                }
            }
        }

        #endregion

        #region Useful Methods

        /// <summary>
        /// Returns the point on this map's grid corresponding to the specified point
        /// </summary>
        /// <param name="rawPoint">The point to convert to grid-point</param>
        /// <returns>The grid point corresponding to the specified point</returns>
        public Vector2 GetGridPoint(Vector2 rawPoint)
        {
            return GetGridPoint(rawPoint, TileSize);
        }

        /// <summary>
        /// Returns the point with the specified grid size corresponding to the specified point
        /// </summary>
        /// <param name="rawPoint">The point to convert to grid-point</param>
        /// <param name="tileSize">The size of each tile on the grid</param>
        /// <returns>The grid point corresponding to the specified point</returns>
        public static Vector2 GetGridPoint(Vector2 rawPoint, float tileSize)
        {
            return Vector2.Floor(rawPoint / new Vector2(tileSize));
        }

        #endregion
    }
}
