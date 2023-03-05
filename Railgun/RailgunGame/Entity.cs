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
    internal class Entity
    {
        /// <summary>
        /// entity's location and hitbox
        /// </summary>
        public Rectangle Hitbox { get; set; }

        /// <summary>
        /// entity's sprite
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// intatntiates a geenric entity with a 
        /// location, hitbox, and sprite
        /// </summary>
        public Entity(Rectangle hitbox, Texture2D texture) 
        {
            Hitbox = hitbox;
            Texture = texture;
        }
    }
}
