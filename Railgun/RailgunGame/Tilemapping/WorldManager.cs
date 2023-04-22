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
        }

        /// <summary>
        /// The singleton instance of this world manager
        /// </summary>
        public static WorldManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorldManager();
                }
                return instance;
            }
        }
        private static WorldManager instance;

        #endregion

        /// <summary>
        /// A random object for anything that needs a bit of non-deterministic magic
        /// </summary>
        public Random RNG { get; private set; }

        /// <summary>
        /// The current map of the world
        /// </summary>
        public Map CurrentMap { get; private set; }

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
            NextMap = PossibleMaps[RNG.Next(PossibleMaps.Count)];//Random map

            MakeCurrentRoom();
        }

        /// <summary>
        /// Sets up the world manager with the specified possible maps
        /// </summary>
        /// <param name="graphicsDevice">The graphics device to be used for the camera</param>
        /// <param name="mapPossibilities"></param>
        /// <param name="startingMap">The map to start in</param>
        public void SetupWorld(GraphicsDevice graphicsDevice, List<Map> mapPossibilities, Map startingMap)
        {
            PossibleMaps = mapPossibilities;

            PreviousMap = Map.Empty();
            CurrentMap = startingMap;
            NextMap = PossibleMaps[RNG.Next(PossibleMaps.Count)];//Random map

            //Create cam
            CurrentCamera = new Camera(graphicsDevice, Rectangle.Empty);
            MakeCurrentRoom();
        }

        /// <summary>
        /// Sets up entities and other info for a new current room
        /// </summary>
        private void MakeCurrentRoom()
        {
            //Set cam bounds
            CurrentCamera.TargetBounds = CurrentMap.Bounds;
            //Position entrence of this map at the exit of the map before it
            NextMap.Position = CurrentMap.Exit - NextMap.Entrence;
            //Populate enemy list
            CurrentEnemies = CurrentMap.GenerateEnemyList();
        }
    }
}
