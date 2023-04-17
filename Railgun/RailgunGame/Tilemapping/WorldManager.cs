using Microsoft.Xna.Framework;
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
        /// The singleton instance of this InputManager
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
        /// The current map of the world
        /// </summary>
        //public Map CurrentMap => Maps[MapIndex];
        public Map CurrentMap { get; set; }

        /// <summary>
        /// The next map in the list
        /// </summary>
        public Map NextMap => Maps[MapIndex + 1];

        /// <summary>
        /// All maps to be used
        /// </summary>
        public List<Map> Maps { get; set; }

        /// <summary>
        /// The index of the current map
        /// </summary>
        public int MapIndex { get; set; } = 0;

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
    }
}
