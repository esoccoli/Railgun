using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.RailgunGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame
{
    /// <summary>
    /// An entity that represents a door
    /// </summary>
    internal class Door : Entity
    {
        private Texture2D texture;
        
        /// <summary>
        /// Creates a new door
        /// </summary>
        /// <param name="texture">The texture of the door</param>
        /// <param name="hitbox"></param>
        public Door(Rectangle hitbox) : base(hitbox)
        {
            texture = VisualManager
        }


    }
}
