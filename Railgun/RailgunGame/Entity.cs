using Microsoft.Xna.Framework;

// Nathan McAndrew
// Generic entity with a hitbox and texture
namespace Railgun.RailgunGame
{
    /// <summary>
    /// Base class that stores data that all entities in the game will have (ie: hitbox, texture)
    /// </summary>
    internal abstract class Entity
    {
        /// <summary>
        /// Entity's location and hitbox
        /// </summary>
        public Rectangle Hitbox { get; set; }

        /// <summary>
        /// Instantiates a generic entity with a location, hitbox, and sprite
        /// </summary>
        protected Entity(Rectangle hitbox)
        {
            Hitbox = hitbox;
        }

        /// <summary>
        /// Updates the status of the entity
        /// </summary>
        /// <param name="gameTime">Time of the game</param>
        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// Updates the status of the entity. Literally only used for Player.Update
        /// </summary>
        /// <param name="gameTime">Time of the game</param>
        /// <param name="canHeal">Whether the main player can heal</param>
        public virtual void Update(GameTime gameTime, bool canHeal) { }
    }
}
