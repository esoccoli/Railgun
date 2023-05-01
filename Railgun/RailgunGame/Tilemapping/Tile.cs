using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Nathan McAndrew, Jonathan Jan
//Class that holds all tiles in the game
namespace Railgun.RailgunGame.Tilemapping
{
    // TODO: add XML header
    internal struct Tile
    {
        /// <summary>
        /// tile's texture
        /// </summary>
        public Texture2D Texture { get; }

        /// <summary>
        /// source rectangle on sprite sheet
        /// </summary>
        public Rectangle? SourceRectangle { get; }

        /// <summary>
        /// rotation of the tile
        /// </summary>
        public float Rotation { get; }

        /// <summary>
        /// tint to apply to tile
        /// </summary>
        public Color Tint { get; }

        /// <summary>
        /// sprite effect to apply to tile
        /// (flip horizontally or vetically)
        /// </summary>
        public SpriteEffects Flip { get; }

        /// <summary>
        /// Creates a new tile with the specified parameters
        /// </summary>
        /// <param name="texture">tile's texture</param>
        /// <param name="sourceRectangle">section of texture with desired tile</param>
        /// <param name="rotation">roataion of the tile</param>
        /// <param name="tint">tint of the tile</param>
        /// <param name="flip">which way the tile is flipped</param>
        public Tile(Color tint, 
                    Texture2D texture = null,
                    Rectangle? sourceRectangle = null,
                    float rotation = 0f,
                    SpriteEffects flip = SpriteEffects.None)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            Rotation = rotation;
            Tint = tint;
            Flip = flip;
        }
        
        // TODO: make XML header
        public void Draw(SpriteBatch sb, Rectangle destination)
        {
            //Only draw if not null
            if(Texture != null)
            {
                //Offset destination by center of texture for origin to be at center of tile
                destination.Location = destination.Center;

                Vector2 origin = Texture.Bounds.Size.ToVector2() / 2f;

                //If source is specified, create origin from source rectangle size
                if (SourceRectangle != null)
                    origin = SourceRectangle.Value.Size.ToVector2() / 2f;


                sb.Draw(
                    Texture, destination, SourceRectangle, Tint,
                    Rotation, origin, Flip, 0f);
            }
        }
    }
}
