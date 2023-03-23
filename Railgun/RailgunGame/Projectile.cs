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
        /// Projectile's X and Y velocities
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// current state of the projectile:
        /// active or has collided
        /// </summary>
        public ProjectileStates CurrentState { get; set; }

        /// <summary>
        /// animation to play when projectile is active
        /// </summary>
        public Texture2D IsActive { get; set; }

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
                          Texture2D isActiveTexture,
                          Animation hasCollidedAnimation,
                          Vector2 Velocity)

            : base(hitbox,
                   isActiveTexture)
        {
            this.Velocity = Velocity;
            IsActive = isActiveTexture;
            HasCollided = hasCollidedAnimation;

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
                    Hitbox = new Rectangle((int)(Hitbox.X + Velocity.X), (int)(Hitbox.Y + Velocity.Y), Hitbox.Width, Hitbox.Height);
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
        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            switch (CurrentState)
            {
                case ProjectileStates.IsActive:
                    sb.Draw(IsActive, new Rectangle(Hitbox.X, Hitbox.Y, IsActive.Width,IsActive.Height), Color.White);
                    break;

                case ProjectileStates.HasCollided:
                    if (HasCollided.CurrentFrame != HasCollided.TotalFrames)
                    {
                        HasCollided.Draw(sb, gameTime, new Vector2(Hitbox.X, Hitbox.Y));
                    }
                    break;
            }
        }
    }
}
