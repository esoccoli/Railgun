using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Controls;
using Railgun.Editor.App.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Util
{
    /// <summary>
    /// A delegate that represents a generic method with no parameters or return value
    /// </summary>
    public delegate void GenericDelegate();

    ///// <summary>
    ///// Any delegate that a control event will use (button press, etc)
    ///// </summary>
    //public delegate void ControlDelegate(object sender, EventArgs e);

    /// <summary>
    /// A singleton style manager containing useful info
    /// and properties about tiles and editor selections
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/23/2023
    /// </summary>
    internal class TileManager
    {

        #region Singleton Design

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
            CurrentTile = Tile.Empty;
            SelectedTiles = new List<Tile>();
        }

        #endregion

        /// <summary>
        /// The current tile to be placed
        /// </summary>
        public Tile CurrentTile
        {
            get => currentTile;
            set
            {
                currentTile = value;
                //Invalidates current tile display if not null
                OnCurrentTileChange?.Invoke();
            }
        }
        private Tile currentTile;

        /// <summary>
        /// A list of selected tiles to be edited
        /// </summary>
        public List<Tile> SelectedTiles { get; private set; }

        

        #region Edit Invokers

        /// <summary>
        /// Rotates the current tile 90 degrees clockwise OR
        /// rotates the current selection by 90 degrees clockwise
        /// </summary>
        public void RotateCW() => OnRotateCW?.Invoke();

        /// <summary>
        /// Rotates the current tile 90 degrees counter-clockwise OR
        /// rotates the current selection by 90 degrees counter-clockwise
        /// </summary>
        public void RotateCCW() => OnRotateCCW?.Invoke();
        /// <summary>
        /// Flips the current tile horizontally OR
        /// Flips the current selection horizontally
        /// </summary>
        public void FlipHorizontal() => OnFlipHorizontal?.Invoke();

        /// <summary>
        /// Flips the current tile vertically OR
        /// Flips the current selection vertically
        /// </summary>
        public void FlipVertical() => OnFlipVertical?.Invoke();

        /// <summary>
        /// Moves the current tile up OR
        /// Moves the current selection up
        /// </summary>
        public void MoveUp() => OnMoveUp?.Invoke();

        /// <summary>
        /// Moves the current tile down OR
        /// Moves the current selection down
        /// </summary>
        public void MoveDown() => OnMoveDown?.Invoke();

        /// <summary>
        /// Moves the current tile left OR
        /// Moves the current selection left
        /// </summary>
        public void MoveLeft() => OnMoveLeft?.Invoke();

        /// <summary>
        /// Moves the current tile right OR
        /// Moves the current selection right
        /// </summary>
        public void MoveRight() => OnMoveRight?.Invoke();

        #endregion

        #region Events

        /// <summary>
        /// An event that is called when the current tile is changed
        /// </summary>
        public event GenericDelegate OnCurrentTileChange;

        //Edit events

        /// <summary>
        /// Rotates the current tile 90 degrees clockwise OR
        /// rotates the current selection by 90 degrees clockwise
        /// </summary>
        public event GenericDelegate OnRotateCW;
        /// <summary>
        /// Rotates the current tile 90 degrees counter-clockwise OR
        /// rotates the current selection by 90 degrees counter-clockwise
        /// </summary>
        public event GenericDelegate OnRotateCCW;
        /// <summary>
        /// Flips the current tile horizontally OR
        /// Flips the current selection horizontally
        /// </summary>
        public event GenericDelegate OnFlipHorizontal;
        /// <summary>
        /// Flips the current tile vertically OR
        /// Flips the current selection vertically
        /// </summary>
        public event GenericDelegate OnFlipVertical;
        /// <summary>
        /// Moves the current tile up OR
        /// Moves the current selection up
        /// </summary>
        public event GenericDelegate OnMoveUp;
        /// <summary>
        /// Moves the current tile down OR
        /// Moves the current selection down
        /// </summary>
        public event GenericDelegate OnMoveDown;
        /// <summary>
        /// Moves the current tile left OR
        /// Moves the current selection left
        /// </summary>
        public event GenericDelegate OnMoveLeft;
        /// <summary>
        /// Moves the current tile right OR
        /// Moves the current selection right
        /// </summary>
        public event GenericDelegate OnMoveRight;

        #endregion
    }
}
