using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Nathan McAndrew
//Class for all projectiles in the game
namespace Railgun.RailgunGame
{
    internal class Projectile : Entity
    {
        /// <summary>
        /// possible animation states for projectiles
        /// </summary>
        public enum ProjectileStates
        {
            IsActive,
            HasCollided
        }

        /// <summary>
        /// speed at which projectile's x value updates
        /// </summary>
        public float XVelocity { get; set; }

        /// <summary>
        /// speed at which projectile's y value updates
        /// </summary>
        public float YVelocity { get; set; }

        /// <summary>
        /// current state of the projectile:
        /// active or has collided
        /// </summary>
        public ProjectileStates CurrentState { get; set; }

        /// <summary>
        /// animation to play when projectile is active
        /// </summary>
        public Animation IsActive { get; set; }

        /// <summary>
        /// animation to play when projectile collides
        /// </summary>
        public Animation HasCollided { get; set; }

        /// <summary>
        /// instantiates a projectile
        /// </summary>
        /// <param name="hitbox">hitbox of projectile</param>
        /// <param name="texture">texture of projectile</param>
        public Projectile(Rectangle hitbox,
                          Texture2D texture,
                          GameTime gameTime,
                          float xVelocity,
                          float yVelocity)

            : base(hitbox,
                   texture,
                   gameTime)
        {

            XVelocity = xVelocity;
            YVelocity = yVelocity;

        }

        /// <summary>
        /// checks if a projectile has collided with an entity
        /// </summary>
        /// <param name="check">entity to check collision with</param>
        public void CheckCollision(Entity check)
        {
            // has hit an entity
            if (check.Hitbox.Intersects(this.Hitbox))
            {
                CurrentState = ProjectileStates.HasCollided;
            }
        }

        /// <summary>
        /// updates the current state and position
        /// of the projectile
        /// </summary>
        /// <param name="gameTime">GameTime</param>
        public void Update(GameTime gameTime, Entity check)
        {
            switch (CurrentState)
            {
                case ProjectileStates.IsActive:
                    //replace old location with new location
                    break;

                case ProjectileStates.HasCollided:
                    //do nothing
                    break;
            }
        }

        /// <summary>
        /// Draws the projectile with 
        /// the specified properties
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        public void Draw(SpriteBatch sb)
        {
            switch (CurrentState)
            {
                case ProjectileStates.IsActive:
                    IsActive.Draw(sb, GameTime, new Vector2(Hitbox.X, Hitbox.Y));
                    break;

                case ProjectileStates.HasCollided:
                    HasCollided.Draw(sb, GameTime, new Vector2(Hitbox.X, Hitbox.Y));
                    break;
            }
        }
    }
}
