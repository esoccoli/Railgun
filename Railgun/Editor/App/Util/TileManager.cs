﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Objects.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Util
{
    /// <summary>
    /// A singleton style manager containing useful info
    /// and properties about tiles and editor selections
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/23/2023
    /// </summary>
    internal class TileManager
    {
        /// <summary>
        /// The instance of this tile manager
        /// </summary>
        public static TileManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new TileManager();
                return instance;
            }
        }
        private static TileManager instance;

        /// <summary>
        /// Creates a new tile manager
        /// </summary>
        public TileManager()
        {

            CurrentTile = null;
        }

        /// <summary>
        /// The current tile to be placed
        /// </summary>
        public Tile CurrentTile { get; set; }

        /// <summary>
        /// A list of selected tiles to be edited
        /// </summary>
        public List<Tile> SelectedTiles { get; private set; }
    }
}
