using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Nathan McAndrew
//Generic entity with a hitbox and texture
namespace Railgun.RailgunGame
{
    internal abstract class Entity
    {
        /// <summary>
        /// entity's location and hitbox
        /// </summary>
        public Rectangle Hitbox { get; set; }

        /// <summary>
        /// intatntiates a geenric entity with a 
        /// location, hitbox, and sprite
        /// </summary>
        public Entity(Rectangle hitbox)
        {
            Hitbox = hitbox;
        }

        /// <summary>
        /// updates the status of the entity
        /// </summary>
        /// <param name="gameTime">time of the game</param>
        public virtual void Update(GameTime gameTime) { }
    }
}
