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
        /// entity's primary sprite 
        /// (idle for player/enemy, active for projectiles)
        /// </summary>
        public Texture2D Texture { get; set; }

        public GameTime GameTime { get; set; }

        /// <summary>
        /// intatntiates a geenric entity with a 
        /// location, hitbox, and sprite
        /// </summary>
        public Entity(Rectangle hitbox, Texture2D texture, GameTime gameTime) 
        {
            Hitbox = hitbox;
            Texture = texture;
            GameTime = gameTime;
        }

        /// <summary>
        /// updates the status of the entity
        /// </summary>
        /// <param name="gameTime">time of the game</param>
        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// draws the object
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Hitbox, Color.White);
        }
    }

}
