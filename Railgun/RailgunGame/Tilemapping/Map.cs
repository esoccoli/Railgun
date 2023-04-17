using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.RailgunGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Tilemapping
{
    /// <summary>
    /// Represents a map of tiles within the game
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/9/2023
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
                if (value > 0)
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
        public List<Dictionary<Vector2, Tile>> Layers { get; private set; }

        /// <summary>
        /// A boolean dictionary that maps position to boolean of whether a tile is solid or not
        /// </summary>
        public Dictionary<Vector2, bool> HitboxesMap { get; private set; }

        /// <summary>
        /// The list of hitboxes on this map
        /// </summary>
        public List<Rectangle> Hitboxes { get; private set; }

        /// <summary>
        /// The created bounds of this map
        /// </summary>
        public Rectangle Bounds { get; private set; }

        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                //Update hitbox locations
                for(int i = 0; i < Hitboxes.Count; i++)
                {
                    Rectangle hitbox = Hitboxes[i];
                    hitbox.Location = position.ToPoint();
                    Hitboxes[i] = hitbox;
                }
            }
        }
        private Vector2 position;

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
            HitboxesMap = new Dictionary<Vector2, bool>();
            Hitboxes = new List<Rectangle>();
        }

        /// <summary>
        /// Generates a list of hitboxes based on the dictionary of hitboxes
        /// and the bounds of the map (should be called after all tiles have been added)
        /// </summary>
        public void GenerateMapValues()
        {
            //Populate the list of hitboxes
            foreach (KeyValuePair<Vector2, bool> hitbox in HitboxesMap)
            {
                //If solid, add it to the list
                if (hitbox.Value)
                {
                    Hitboxes.Add(
                        new Rectangle((hitbox.Key * TileSize).ToPoint(),
                        new Point(tileSize)));
                }
            }
            
            //Create bounds
            Rectangle bounds = Hitboxes.First();
            Point bottomRightTile = Hitboxes.First().Location;

            //Create bounds of map
            foreach (Rectangle hitbox in Hitboxes)
            {
                //Find top most left tile
                if (hitbox.X < bounds.X) bounds.X = hitbox.X;
                if (hitbox.Y < bounds.Y) bounds.Y = hitbox.Y;
                //Find bottom most right tile
                if (hitbox.X > bottomRightTile.X) bottomRightTile.X = hitbox.X;
                if (hitbox.Y > bottomRightTile.Y) bottomRightTile.Y = hitbox.Y;
            }
            //Create final rectangle size
            bottomRightTile += new Point(tileSize);
            bounds.Size = new Point(
                    bottomRightTile.X - bounds.X,
                    bottomRightTile.Y - bounds.Y);
            bounds.Inflate(100f, 100f);
            Bounds = bounds;
        }

        #region Drawing

        /// <summary>
        /// Draws this map's tiles to the specified sprite batch
        /// </summary>
        /// <param name="spriteBatch">THe sprite batch to draw to</param>
        public void DrawTiles(SpriteBatch spriteBatch)
        {
            //Draw each layer
            foreach (Dictionary<Vector2, Tile> layer in Layers)
            {
                //Draw each tile in this layer
                foreach (KeyValuePair<Vector2, Tile> tile in layer)
                {
                    //Draw the tile to rectangle corresponding to its grid location
                    tile.Value.Draw(
                        spriteBatch, new Rectangle(
                            (tile.Key * TileSize + Position).ToPoint(),
                            new Point(TileSize)));
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

            foreach (KeyValuePair<Vector2, bool> hitbox in HitboxesMap)
            {
                //If hitbox placed
                if (hitbox.Value)
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
                    ShapeBatch.Line(topLeftCorner + Position, bottomRightCorner, 2f, Color.Red);
                    ShapeBatch.Line(
                        new Vector2(topLeftCorner.X, bottomRightCorner.Y) + Position,
                        new Vector2(bottomRightCorner.X, topLeftCorner.Y) + Position, 2f, Color.Red);
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
            return GetGridPoint(rawPoint, TileSize, Position);
        }

        /// <summary>
        /// Returns the point with the specified grid size corresponding to the specified point
        /// </summary>
        /// <param name="rawPoint">The point to convert to grid-point</param>
        /// <param name="tileSize">The size of each tile on the grid</param>
        /// <returns>The grid point corresponding to the specified point</returns>
        public static Vector2 GetGridPoint(Vector2 rawPoint, float tileSize, Vector2 position)
        {
            return Vector2.Floor(rawPoint / new Vector2(tileSize)) + position;
        }

        /// <summary>
        /// Checks this map's solid hitboxes against the specified hitbox.
        /// Returns the resolved hitbox
        /// (shamelessly copied from the gravity and collisions pe)
        /// </summary>
        /// <param name="hitbox">Hitbox to resolve</param>
        /// <return>The resolved hitbox</return>
        public Rectangle ResolveCollisions(Rectangle hitbox)
        {
            List<Rectangle> intersections = new List<Rectangle>();

            //Add intersections
            foreach (Rectangle obstical in Hitboxes)
            {
                //Check if it has a width or height
                if (obstical.Intersects(hitbox))
                {
                    intersections.Add(obstical);
                }
            }

            //Check and move x
            foreach (Rectangle obstical in intersections)
            {
                Rectangle intersection = Rectangle.Intersect(hitbox, obstical);
                //Check if valid and for width
                if (intersection.Height > intersection.Width)
                {
                    //Calculate side
                    if (hitbox.X < obstical.X)
                    {
                        hitbox.X -= intersection.Width;
                    }
                    else
                    {
                        hitbox.X += intersection.Width;
                    }

                }
            }

            //Check and move y
            foreach (Rectangle obstical in intersections)
            {
                Rectangle intersection = Rectangle.Intersect(hitbox, obstical);

                //Check if valid and for width
                if (intersection.Width > intersection.Height)
                {
                    //Calculate side
                    if (hitbox.Y < obstical.Y)
                    {
                        hitbox.Y -= intersection.Height;
                    }
                    else
                    {
                        hitbox.Y += intersection.Height;
                    }
                }
            }

            //Set new hitbox
            return hitbox;
        }

        /// <summary>
        /// Returns whether 
        /// </summary>
        /// <param name="gridPoint"></param>
        /// <returns></returns>
        public bool IsSolid(Vector2 gridPoint)
        {
            //If it exists, overwrite the value
            HitboxesMap.TryGetValue(gridPoint, out bool returnValue);
            return returnValue;
        }

        /// <summary>
        /// Returns an empty map
        /// </summary>
        /// <returns></returns>
        public static Map Empty()
        {
            return new Map(0);
        }

        #endregion
    }
}
