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
            private set
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
        public Dictionary<Vector2, bool> Hitboxes { get; private set; }

        /// <summary>
        /// The list of active solid hitboxes for debug drawing
        /// </summary>
        private List<Vector2> activeHitboxes;

        /// <summary>
        /// A dictionary of entity ids that this map contains
        /// </summary>
        public Dictionary<Vector2, int> EntitiesDictionary { get; private set; }

        /// <summary>
        /// The entrence point of this map
        /// </summary>
        public Vector2 Entrence { get; set; }

        /// <summary>
        /// The exit point of this map
        /// </summary>
        public Vector2 Exit { get; set; }

        /// <summary>
        /// The created bounds of this map
        /// </summary>
        public Rectangle Bounds { get; private set; }

        /// <summary>
        /// The position of the map
        /// </summary>
        public Vector2 Position
        {
            get => position;
            set
            {
                Vector2 changeInPosition = value - position;
                position = value;
                Rectangle bounds = Bounds;
                bounds.Location += changeInPosition.ToPoint();
                Bounds = bounds;
                Entrence += changeInPosition;
                Exit += changeInPosition;
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
            Hitboxes = new Dictionary<Vector2, bool>();
            activeHitboxes = new List<Vector2>();
            EntitiesDictionary = new Dictionary<Vector2, int>();
            Entrence = Vector2.Zero;
            Exit = Vector2.Zero;
        }

        /// <summary>
        /// Generates a list of hitboxes based on the dictionary of hitboxes
        /// and the bounds of the map (should be called after all tiles have been added)
        /// </summary>
        public void GenerateMapValues()
        {
            //If hitboxes are available, create bounds
            if(Hitboxes.Count > 0)
            {
                Rectangle bounds = Rectangle.Empty;
                Point bottomRightTile = Point.Zero;

                //Create bounds of map
                foreach(KeyValuePair<Vector2, bool> hitboxPair in Hitboxes)
                {
                    //If solid, create a hitbox and compare
                    if(hitboxPair.Value)
                    {
                        Rectangle hitbox = GetSolidTile(hitboxPair.Key);

                        //Find top most left tile
                        if (hitbox.X < bounds.X) bounds.X = hitbox.X;
                        if (hitbox.Y < bounds.Y) bounds.Y = hitbox.Y;
                        //Find bottom most right tile
                        if (hitbox.X > bottomRightTile.X) bottomRightTile.X = hitbox.X;
                        if (hitbox.Y > bottomRightTile.Y) bottomRightTile.Y = hitbox.Y;
                    }
                }
                //Create final rectangle size
                bottomRightTile += new Point(tileSize);
                bounds.Size = new Point(
                        bottomRightTile.X - bounds.X,
                        bottomRightTile.Y - bounds.Y);
                bounds.Inflate(100f, 100f);
                Bounds = bounds;
            }

            //Calculate entrence and exit positions
            Entrence *= TileSize;
            Exit *= TileSize;
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
                    tile.Value.Draw(spriteBatch, GetSolidTile(tile.Key));
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
            foreach (KeyValuePair<Vector2, bool> hitbox in Hitboxes)
            {
                //If hitbox placed
                if (hitbox.Value)
                {
                    DrawSingleHitbox(
                        cameraOffset, cameraZoom, 
                        hitbox.Key * TileSize, Color.Magenta * 0.2f);
                }
            }

            //Draw active hitboxes
            foreach(Vector2 hitboxPoint in activeHitboxes)
            {
                DrawSingleHitbox(
                    cameraOffset, cameraZoom,
                    hitboxPoint * TileSize, Color.Red);
            }
            //Reset active hitboxes
            activeHitboxes.Clear();

        }

        /// <summary>
        /// Draws a single debug hitbox with the specified values
        /// </summary>
        /// <param name="cameraOffset">Offset of camera</param>
        /// <param name="cameraZoom">Zoom of camera</param>
        /// <param name="position">Position of hitbox</param>
        /// <param name="tint">The color to draw it</param>
        private void DrawSingleHitbox(Vector2 cameraOffset, float cameraZoom,
            Vector2 position, Color tint)
        {
            DrawSingleHitbox(cameraOffset, cameraZoom, position, new Vector2(TileSize), Position, tint);
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
        /// <param name="offset">The offset or position of the map</param>
        /// <returns>The grid point corresponding to the specified point</returns>
        public static Vector2 GetGridPoint(Vector2 rawPoint, float tileSize, Vector2 offset)
        {
            return Vector2.Floor((rawPoint - offset) / new Vector2(tileSize));
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
            //Get hitbox location in grid-space and then some
            Vector2 gridPos = GetGridPoint(hitbox.Location.ToVector2());
            //Get the amount of tiles to the bottom right that this hitbox reaches and then some
            Vector2 maxGridReach =
                Vector2.Ceiling((hitbox.Size.ToVector2() / TileSize)) + Vector2.One;

            List<Rectangle> intersections = new List<Rectangle>();

            //Check each grid point that is within hitbox range
            for (int x = 0; x < maxGridReach.X; x++)
            {
                for (int y = 0; y < maxGridReach.Y; y++)
                {
                    //The grid point to check
                    Vector2 gridPoint = new Vector2(x, y) + gridPos;
                    //If there is collision, add to collision list
                    if(IsSolid(gridPoint))
                    {
                        intersections.Add(GetSolidTile(gridPoint));
                        //Add a debug list of hitboxes to draw
                        activeHitboxes.Add(gridPoint);
                    }
                }
            }

            return ResolveCollisions(hitbox, intersections);
        }

        /// <summary>
        /// A general method for resolving collisions between specified hitbox and solids
        /// </summary>
        /// <param name="hitbox">The hitbox to check</param>
        /// <param name="intersections">The solids to repel from</param>
        /// <returns>The resolved hitbox</returns>
        public static Rectangle ResolveCollisions(Rectangle hitbox, List<Rectangle> intersections)
        {
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
                if (intersection.Width >= intersection.Height)
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

            //Return new hitbox
            return hitbox;
        }

        /// <summary>
        /// Returns whether the tile grid point specified is solid
        /// </summary>
        /// <param name="gridPoint"></param>
        /// <returns></returns>
        public bool IsSolid(Vector2 gridPoint)
        {
            //If it exists, overwrite the value
            Hitboxes.TryGetValue(gridPoint, out bool returnValue);
            return returnValue;
        }

        /// <summary>
        /// Returns a world-space tile hitbox based on the specified grid point
        /// <para>NOTE: this does not check if it is actually solid, it
        /// will create a solid hitbox regardless</para>
        /// </summary>
        /// <param name="gridPoint">The grid point to create from</param>
        /// <returns>The solid hitbox</returns>
        public Rectangle GetSolidTile(Vector2 gridPoint)
        {
            return new Rectangle(
                (gridPoint * TileSize).ToPoint() + Position.ToPoint(),
                new Point(TileSize));
        }

        /// <summary>
        /// Generates a list of enemies based on the current position
        /// </summary>
        /// <returns>List of enemies</returns>
        public List<Enemy> GenerateEnemyList()
        {
            List<Enemy> enemies = new List<Enemy>();

            //Generate entities
            foreach (KeyValuePair<Vector2, int> entityPair in EntitiesDictionary)
            {
                //Hitbox for any entity
                Rectangle hitbox = GetSolidTile(entityPair.Key);

                //Create enemy based on ID
                switch (entityPair.Value)
                {
                    case 0://Enemy 1
                        enemies.Add(new Skeleton(hitbox));
                        break;
                    case 1://Enemy 2
                        enemies.Add(new GasMan(hitbox));
                        break;
                    case 2://Enemy 3
                        enemies.Add(new Turret(hitbox));
                        break;
                    case 3://Enemy 4
                        
                        break;
                }
            }

            return enemies;
        }

        /// <summary>
        /// Creates and returns a shallow copy of this map
        /// </summary>
        /// <returns>A shallow copy of the map</returns>
        public Map Clone()
        {
            return MemberwiseClone() as Map;
        }

        /// <summary>
        /// Returns an empty map
        /// </summary>
        /// <returns>Empty map</returns>
        public static Map Empty()
        {
            return new Map(0);
        }

        /// <summary>
        /// Draws a single debug hitbox with the specified values
        /// </summary>
        /// <param name="cameraOffset">Offset of camera</param>
        /// <param name="cameraZoom">Zoom of camera</param>
        /// <param name="position">Position of hitbox</param>
        /// <param name="size">The size of the hitbox</param>
        /// <param name="offset">The offset of the map or world</param>
        /// <param name="tint">The color to draw it</param>
        public static void DrawSingleHitbox(Vector2 cameraOffset, float cameraZoom,
            Vector2 position, Vector2 size, Vector2 offset, Color tint)
        {
            Vector2 sizeVector = size * cameraZoom;

            //Compute position to draw
            Vector2 topLeftCorner = (position + offset) * cameraZoom + cameraOffset;
            Vector2 bottomRightCorner = topLeftCorner + sizeVector;

            //Draw box of bounds
            ShapeBatch.BoxOutline(
                new Rectangle(
                    topLeftCorner.ToPoint(),
                    sizeVector.ToPoint()), tint);
            //Draw x in the middle
            ShapeBatch.Line(topLeftCorner, bottomRightCorner, 2f, tint);
            ShapeBatch.Line(
                new Vector2(topLeftCorner.X, bottomRightCorner.Y),
                new Vector2(bottomRightCorner.X, topLeftCorner.Y), 2f, tint);
        }

        #endregion
    }
}
