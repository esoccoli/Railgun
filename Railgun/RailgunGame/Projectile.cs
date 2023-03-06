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
        /// speed at which projectile's x value updates
        /// </summary>
        public float XVelocity { get; set; }

        /// <summary>
        /// speed at which projectile's y value updates
        /// </summary>
        public float YVelocity { get; set; }

        /// <summary>
        /// determines if a projectile is activre or not
        /// </summary>
        public bool IsActive { get;  protected set; }
        
        /// <summary>
        /// instantiates a projectile
        /// </summary>
        /// <param name="hitbox">hitbox of projectile</param>
        /// <param name="texture">texture of projectile</param>
        public Projectile(Rectangle hitbox, Texture2D texture, float xVelocity, float yVelocity)
            : base(hitbox, texture) 
        {

            XVelocity = xVelocity;
            YVelocity = yVelocity;

            //should change when it intersects
            IsActive = true;
        }

        /// <summary>
        /// checks if a projectile has collided with an entity
        /// </summary>
        /// <param name="check">entity to check collision with</param>
        /// <returns>whether or not the projectile has collided</returns>
        public bool CheckCollision(Entity check)
        {
            //projectile is still in a data structure but inactive
            if (!IsActive)
            {
                return false;
            }

            //has hit an entity
            if (check.Hitbox.Intersects(this.Hitbox))
            {
                IsActive = false;
                //switch from active animation to collided animation
                //_hasHit = true;
                //_currentFrame = 0;
                return true;
            }

            return false;
        }
    }
}
