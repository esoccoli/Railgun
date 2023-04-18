using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Railgun.RailgunGame.Tilemapping;
using Railgun.RailgunGame.Util;

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
        /// The current position of the bullet. BOY this has a story behind it...
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// current state of the projectile:
        /// active or has collided
        /// </summary>
        public ProjectileStates CurrentState { get; set; }

        /// <summary>
        /// animation to play when projectile is active
        /// </summary>
        public Texture2D ActiveTexture { get; set; }

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
                          Vector2 Velocity) : base(hitbox)
        {
            this.Velocity = Velocity;
            ActiveTexture = isActiveTexture;
            HasCollided = hasCollidedAnimation;
            Position = Hitbox.Center.ToVector2();
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
        public void Update(GameTime gameTime)
        {
            switch (CurrentState)
            {
                case ProjectileStates.IsActive:
                    Position += Velocity;
                    Hitbox = new Rectangle((int)(Hitbox.X + Velocity.X), (int)(Hitbox.Y + Velocity.Y), Hitbox.Width, Hitbox.Height);
                    break;

                case ProjectileStates.HasCollided:
                    //do nothing
                    break;
            }
            Vector2 gridPos = WorldManager.Instance.CurrentMap.GetGridPoint(Position);

            if (WorldManager.Instance.CurrentMap.IsSolid(gridPos))
            {
                CurrentState = ProjectileStates.HasCollided;
            }
        }

        /// <summary>
        /// Draws the projectile with 
        /// the specified properties
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        public bool Draw(SpriteBatch sb, GameTime gameTime)
        {
            switch (CurrentState)
            {
                case ProjectileStates.IsActive:
                    sb.Draw(ActiveTexture, new Rectangle((int)(Position.X - (ActiveTexture.Width / 2)), (int)(Position.Y - (ActiveTexture.Height / 2)), ActiveTexture.Width, ActiveTexture.Height), Color.LightSkyBlue);
                    break;

                case ProjectileStates.HasCollided:
                    if (HasCollided.CurrentFrame != HasCollided.TotalFrames)
                    {
                        // We need to subtract from Position half the width of the animation rectangle and bullet texture.
                        return HasCollided.Draw(sb, gameTime, new Vector2(Position.X - (50 - (ActiveTexture.Width /2)), Position.Y - (50 - (ActiveTexture.Height / 2))), Color.White, SpriteEffects.None);
                    }
                    break;
            }
            return false;
        }
    }
}