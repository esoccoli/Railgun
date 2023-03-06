using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        /// instantiates a projectile
        /// </summary>
        /// <param name="hitbox">hitbox of projectile</param>
        /// <param name="texture">texture of projectile</param>
        public Projectile(Rectangle hitbox, Texture2D texture, float xVelocity, float yVelocity)
            : base(hitbox, texture) 
        {
            XVelocity = xVelocity;
            YVelocity = yVelocity;
        }


    }
}
