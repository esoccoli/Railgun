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
    internal class Projectile : Animatable
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

        public ProjectileStates CurrentState { get; set; }

        /// <summary>
        /// instantiates a projectile
        /// </summary>
        /// <param name="hitbox">hitbox of projectile</param>
        /// <param name="texture">texture of projectile</param>
        public Projectile(Rectangle hitbox,
                          Texture2D texture,
                          GameTime gameTime,
                          double fPS,
                          int totalFrames,
                          Rectangle sourceRectangle,
                          Color color,
                          float rotation,
                          Vector2 sourceOrigin,
                          float scale,
                          float layerDepth,
                          float xVelocity,
                          float yVelocity)

            : base(hitbox,
                   texture,
                   gameTime,
                   fPS,
                   totalFrames,
                   sourceRectangle,
                   color,
                   rotation,
                   sourceOrigin,
                   scale,
                   layerDepth)
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
        public void Update(GameTime gameTime)
        {
            switch (CurrentState)
            {
                case ProjectileStates.IsActive:
                    Rectangle tempRectangle = new Rectangle((int)(Hitbox.X + XVelocity), 
                                                            (int)(Hitbox.Y + YVelocity), 
                                                            Hitbox.Width, 
                                                            Hitbox.Height);
                    break;

                case ProjectileStates.HasCollided:
                    break;
            }
        }

        /// <summary>
        /// Draws the projectile 
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        public void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
