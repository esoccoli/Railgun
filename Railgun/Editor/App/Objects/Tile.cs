using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Objects.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Objects
{
    /// <summary>
    /// Represents a tile in the game
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/9/2023
    /// </summary>
    internal class Tile
    {
        /// <summary>
        /// The visual of this tile
        /// </summary>
        public IVisual Visual { get; protected set; }

        /// <summary>
        /// TRUE if this tile is solid
        /// </summary>
        public bool IsSolid { get; set; }

        /// <summary>
        /// Creates a new solid tile with the specified visual
        /// </summary>
        /// <param name="visual">The visual of this tile</param>
        public Tile(IVisual visual) : this(visual, true) { }

        /// <summary>
        /// Creates a new tile with the specified visual and solid status
        /// </summary>
        /// <param name="visual">The visual of this tile</param>
        /// <param name="isSolid">If this tile is solid or not</param>
        public Tile(IVisual visual, bool isSolid)
        {
            Visual = visual;
            IsSolid = isSolid;
        }

        /// <summary>
        /// Draws this tile to the specified sprite batch at 0,0
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw to</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Vector2.Zero);
        }

        /// <summary>
        /// Draws this tile to the specified sprite batch and position
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position"></param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Visual.Draw(spriteBatch, position);
        }

        /// <summary>
        /// Draws this tile to the specified sprite batch and destination rectangle
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw to</param>
        /// <param name="destination">Destination rectangle to draw to</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            Visual.Draw(spriteBatch, destination);
        }

        /// <summary>
        /// Returns a shallow copy of this tile (not a reference)
        /// </summary>
        /// <returns>A new Tile with the same parameters as this</returns>
        public Tile Clone()
        {
            return new Tile(Visual);
        }

        #region Static Prefabs

        /// <summary>
        /// An empty tile
        /// </summary>
        public static Tile Empty => new Tile(VisualElement.Empty, false);

        #endregion
    }
}
