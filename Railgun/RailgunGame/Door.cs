using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.RailgunGame.Util;

namespace Railgun.RailgunGame
{
    /// <summary>
    /// An entity that represents a door
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/22/2023
    /// </summary>
    internal class Door : Entity
    {
        /// <summary>
        /// The texture of this door
        /// </summary>
        private Texture2D texture;

        /// <summary>
        /// The source rectangle for the texture
        /// </summary>
        private Rectangle sourceRectangle;

        /// <summary>
        /// If the door is closed or not
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Creates a new door
        /// </summary>
        /// <param name="hitbox">Hitbox of the door</param>
        public Door(Rectangle hitbox) : base(hitbox)
        {
            texture = VisualManager.Instance.DoorTexture;
            IsClosed = true;
            sourceRectangle = new Rectangle(112, 128, 32, 32);
        }

        /// <summary>
        /// Draws the door
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw to</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsClosed) spriteBatch.Draw(texture, Hitbox, sourceRectangle, Color.White);
        }

    }
}
