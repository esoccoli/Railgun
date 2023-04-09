using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Nathan McAndrew
//Class that holds all tiles in the game
namespace Railgun.RailgunGame.Tilemapping
{
    internal class Tile
    {
        /// <summary>
        /// tile's texture
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// source rectangle on sprite sheet
        /// </summary>
        public Rectangle? SourceRectangle { get; set; }

        /// <summary>
        /// rotation of the tile
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// tint to apply to tile
        /// </summary>
        public Color Tint { get; set; }

        /// <summary>
        /// sprite effect to apply to tile
        /// (flip horizontally or vetically)
        /// </summary>
        public SpriteEffects Flip { get; set; }

        /// <summary>
        /// instantiates a tile with parameters for all values
        /// </summary>
        /// <param name="texture">tile's texture</param>
        /// <param name="sourceRectangle">section of texture with desired tile</param>
        /// <param name="rotation">roataion of the tile</param>
        /// <param name="scale">scale of hitbox to draw tile at</param>
        /// <param name="tint">tint of the tile</param>
        /// <param name="flip">which way the tile is flipped</param>
        public Tile(Texture2D texture,
                    Rectangle? sourceRectangle,
                    float rotation,
                    Color tint,
                    SpriteEffects flip)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            Rotation = rotation;
            Tint = tint;
            Flip = flip;
        }

        /// <summary>
        /// overload with only texture, sourceRectangle, tint, and flip params
        /// rotation = 0.0f
        /// </summary>
        /// <param name="texture">tile's texture</param>
        /// <param name="hitbox">location and size of tile drawn on the screen</param>
        /// <param name="sourceRectangle">source rectangle of tile on texture</param>
        /// <param name="tint">tint applied to tile</param>
        /// <param name="flip">which way the tile is flipped</param>
        public Tile(Texture2D texture,
                    Rectangle? sourceRectangle,
                    Color tint,
                    SpriteEffects flip)
            : this(texture,
                   sourceRectangle,
                   0.0f,
                   tint,
                   flip)
        { }

        /// <summary>
        /// overload with only texture, sourceRectangle, and tint
        /// rotation = 0.0f
        /// flip = SpriteEffects.None
        /// </summary>
        /// <param name="texture">tile's texture</param>
        /// <param name="hitbox">location and size of tile drawn</param>
        /// <param name="sourceRectangle">source rectangle of tile on texture</param>
        /// <param name="tint">color of tile</param>
        public Tile(Texture2D texture,
                    Rectangle? sourceRectangle,
                    Color tint)
            : this(texture,
                  sourceRectangle,
                  0.0f,
                  tint,
                  SpriteEffects.None)
        { }

        /// <summary>
        /// overload whith only a texture, and source rectangle
        /// rotation = 0.0f
        /// tint = Color.White
        /// flip = SpriteEffects.None
        /// </summary>
        /// <param name="texture">tile's texture</param>
        /// <param name="hitbox">location and size of tile drawn on screen</param>
        /// <param name="sourceRectangle">source rectangle of the 
        /// desired tile on the texture</param>
        public Tile(Texture2D texture,
                    Rectangle hitbox,
                    Rectangle? sourceRectangle)
            : this(texture,
                   sourceRectangle,
                   0.0f,
                   Color.White,
                   SpriteEffects.None)
        { }


        public void Draw(SpriteBatch sb, Rectangle destination)
        {
            sb.Draw(Texture, destination, SourceRectangle, Tint, Rotation, Vector2.Zero, Flip, 1.0f);
        }
    }
}
