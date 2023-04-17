using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Tilemapping
{
    /// <summary>
    /// A singleton class that contains useful information about the current map
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/14/2023
    /// </summary>
    internal class MapManager
    {
        #region Singleton Design

        /// <summary>
        /// The singleton instance of this InputManager
        /// </summary>
        public static MapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapManager();
                }
                return instance;
            }
        }
        private static MapManager instance;

        #endregion

        /// <summary>
        /// The current map
        /// </summary>
        public Map CurrentMap { get; set; }
    }
}
