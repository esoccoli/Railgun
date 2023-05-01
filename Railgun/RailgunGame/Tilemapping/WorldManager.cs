using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.RailgunGame.Util;
using System;
using System.Collections.Generic;

namespace Railgun.RailgunGame.Tilemapping
{
    /// <summary>
    /// A singleton class that contains useful information about the world
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/14/2023
    /// </summary>
    internal class WorldManager
    {
        #region Singleton Design

        /// <summary>
        /// Creates a new world manager
        /// </summary>
        private WorldManager()
        {
            PossibleMaps = new List<Map>();
            RNG = new Random();
            CurrentEnemies = new List<Enemy>();
            lastMapIndex = -1;
        }

        /// <summary>
        /// The singleton instance of this world manager
        /// </summary>
        public static WorldManager Instance
        {
            get
            {
                if(instance == null)
                    instance = new WorldManager();
                return instance;
            }
        }
        private static WorldManager instance;

        #endregion

        /// <summary>
        /// A random object for anything that needs a bit of non-deterministic magic
        /// </summary>
        public Random RNG { get; }

        /// <summary>
        /// The current map of the world
        /// </summary>
        public Map CurrentMap { get; private set; }

        /// <summary>
        /// The hitbox for telling if the player has moved to the next room
        /// </summary>
        public Rectangle CurrentExitTrigger { get; private set; }

        /// <summary>
        /// The enterence door of the current room
        /// </summary>
        public Door EntrenceDoor { get; private set; }

        /// <summary>
        /// The exit door of the current room
        /// </summary>
        public Door ExitDoor { get; private set; }

        /// <summary>
        /// The next map in the list
        /// </summary>
        public Map NextMap { get; private set; }

        /// <summary>
        /// The previous map in the list
        /// </summary>
        public Map PreviousMap { get; private set; }

        /// <summary>
        /// All maps that can be used
        /// </summary>
        public List<Map> PossibleMaps { get; private set; }

        /// <summary>
        /// The list of enemies active
        /// </summary>
        public List<Enemy> CurrentEnemies { get; private set; }

        /// <summary>
        /// The current camera of the world
        /// </summary>
        public Camera CurrentCamera { get; set; }

        /// <summary>
        /// The amount of rooms passed
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// The starting map
        /// </summary>
        private Map startingMap;

        /// <summary>
        /// A white square used for debug drawing triggers
        /// </summary>
        private Texture2D whiteSquare;

        /// <summary>
        /// Stores the map index from the random map placement
        /// </summary>
        private int lastMapIndex;

        /// <summary>
        /// Draws all normal game parts of the world (the map)
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw to</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            PreviousMap.DrawTiles(spriteBatch);
            CurrentMap.DrawTiles(spriteBatch);
            NextMap.DrawTiles(spriteBatch);

            //Draw doors
            EntrenceDoor.Draw(spriteBatch);
            ExitDoor.Draw(spriteBatch);
        }

        /// <summary>
        /// Draws all debug parts (solid collision, triggers)
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw to</param>
        /// <param name="graphicsDevice">The graphics device to draw to</param>
        public void DrawDebug(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            //Draw hitboxes
            graphicsDevice.DepthStencilState = DepthStencilState.None;
            ShapeBatch.Begin(graphicsDevice);
            Vector2 cameraOffset = new Vector2(
                CurrentCamera.TransformationMatrix.Translation.X,
                CurrentCamera.TransformationMatrix.Translation.Y);
            
            //Draw map hitboxes
            CurrentMap.DrawHitboxes(cameraOffset, CurrentCamera.Zoom);

            //Draw door hitboxes
            if(EntrenceDoor.IsClosed)
            {
                Map.DrawSingleHitbox(
                    cameraOffset, CurrentCamera.Zoom,
                    EntrenceDoor.Hitbox.Location.ToVector2(),
                    EntrenceDoor.Hitbox.Size.ToVector2(),
                    Vector2.Zero, Color.Blue);
            }
            if(ExitDoor.IsClosed)
            {
                Map.DrawSingleHitbox(
                    cameraOffset, CurrentCamera.Zoom,
                    ExitDoor.Hitbox.Location.ToVector2(),
                    ExitDoor.Hitbox.Size.ToVector2(),
                    Vector2.Zero, Color.Blue);
            }
            ShapeBatch.End();

            //If door is open, draw
            if(!ExitDoor.IsClosed)
            {
                //Draw next room trigger
                spriteBatch.Begin(
                    blendState: BlendState.AlphaBlend,
                    samplerState: SamplerState.PointClamp,
                    transformMatrix: CurrentCamera.TransformationMatrix);
                
                spriteBatch.Draw(whiteSquare, CurrentExitTrigger, Color.Red * 0.2f);

                spriteBatch.End();
            }

            
        }

        /// <summary>
        /// Returns the current mouse position relative to the world
        /// (camera space)
        /// </summary>
        /// <returns>The mouse position within the world</returns>
        public Vector2 GetMouseWorldPosition()
        {
            return CurrentCamera.ScreenToWorld(
                InputManager.MouseState.Position.ToVector2());
        }

        /// <summary>
        /// Moves to the next map and updates map values
        /// </summary>
        public void IncrementMap()
        {
            PreviousMap = CurrentMap;
            CurrentMap = NextMap;
            NextMap = RandomMap();
            Score++;
            MakeCurrentRoom();
        }

        /// <summary>
        /// Resolves collisions with map hitboxes and with solid entities
        /// </summary>
        /// <param name="hitbox">Hitbox to resolve</param>
        /// <returns>A resolved hitbox</returns>
        public Rectangle ResolveCollisions(Rectangle hitbox)
        {
            hitbox = CurrentMap.ResolveCollisions(hitbox);

            //Check entities
            List<Rectangle> entityHitboxes = new List<Rectangle>();
            if(EntrenceDoor.IsClosed) entityHitboxes.Add(EntrenceDoor.Hitbox);
            if(ExitDoor.IsClosed) entityHitboxes.Add(ExitDoor.Hitbox);
            hitbox = Map.ResolveCollisions(hitbox, entityHitboxes);

            return hitbox;
        }

        /// <summary>
        /// Returns if the given world point is colliding with anything collidable
        /// </summary>
        /// <param name="position">Free world point</param>
        /// <returns>TRUE if colliding</returns>
        public bool IsColliding(Vector2 position)
        {
            return CurrentMap.IsSolid(CurrentMap.GetGridPoint(position))
                || (EntrenceDoor.Hitbox.Contains(position) && EntrenceDoor.IsClosed)
                || (ExitDoor.Hitbox.Contains(position) && ExitDoor.IsClosed);
        }

        /// <summary>
        /// Sets up the world manager with the specified possible maps
        /// </summary>
        /// <param name="graphicsDevice">The graphics device to be used for the camera</param>
        /// <param name="mapPossibilities">The possible maps</param>
        /// <param name="startingMap">The map to start in</param>
        public void SetupWorld(GraphicsDevice graphicsDevice, List<Map> mapPossibilities, Map startingMap)
        {
            //Create white square
            whiteSquare = new Texture2D(graphicsDevice, 1, 1);
            whiteSquare.SetData(new Color[] { Color.White });

            PossibleMaps = mapPossibilities;
            this.startingMap = startingMap;

            //Create cam
            CurrentCamera = new Camera(graphicsDevice, Rectangle.Empty);

            ResetWorld();
        }

        /// <summary>
        /// Clones a random map out of the possible maps
        /// </summary>
        /// <returns>Returns a new random map clone</returns>
        private Map RandomMap()
        {
            //Make sure it is not the same map as last time
            int index = RNG.Next(PossibleMaps.Count);
            while(index == lastMapIndex)
            {
                index = RNG.Next(PossibleMaps.Count);
            }
            lastMapIndex = index;
            return PossibleMaps[index].Clone();
        }

        /// <summary>
        /// Sets up entities and other info for a new current room
        /// </summary>
        private void MakeCurrentRoom()
        {
            //Set cam bounds
            CurrentCamera.TargetBounds = CurrentMap.Bounds;
            //Position entrence of this map at the exit of the map before it
            NextMap.Position = CurrentMap.Exit - NextMap.Entrance;
            //Populate enemy list
            CurrentEnemies = CurrentMap.GenerateEnemyList();

            //Create the new exit hitbox
            Point triggerSize = new Point(CurrentMap.TileSize * 4);
            //Have it start 2 tiles above exit indicator
            CurrentExitTrigger =
                new Rectangle(
                    CurrentMap.Exit.ToPoint() -
                    new Point(CurrentMap.TileSize, triggerSize.Y), triggerSize);

            Point doorSize = new Point(CurrentMap.TileSize * 2);
            //Create solid doors
            EntrenceDoor =
                new Door(new Rectangle(CurrentMap.Entrance.ToPoint(), doorSize));
            ExitDoor =
                new Door(new Rectangle(CurrentMap.Exit.ToPoint(), doorSize));
        }

        /// <summary>
        /// Resets the game variables
        /// </summary>
        public void ResetWorld()
        {
            Score = 0;
            PreviousMap = Map.Empty();
            CurrentMap = startingMap;
            NextMap = RandomMap();

            //Set cam bounds to this room instantly (not eased)
            CurrentCamera.CameraBounds = CurrentMap.Bounds;
            CurrentCamera.Position = CurrentMap.Bounds.Center.ToVector2();

            //Get rid of bullets
            EnemyProjManager.Instance.Projectiles.Clear();

            MakeCurrentRoom();
        }
    }
}
