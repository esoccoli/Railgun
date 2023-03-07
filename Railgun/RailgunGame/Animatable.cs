using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Nathan McAndrew
//Class responsible for animating all objects
namespace Railgun.RailgunGame
{
    internal abstract class Animatable : Entity
    {
        //animation elements

        /// <summary>
        /// current frame of sprite sheet
        /// </summary>
        public int CurrentFrame { get; set; }

        /// <summary>
        /// interval that frames are displayed at
        /// </summary>
        public double FPS { get; set; }

        /// <summary>
        /// amount of time one frame should last for
        /// </summary>
        public double SecondsPerFrame { get; set; }

        /// <summary>
        /// time since image was changed
        /// aka "delta time"
        /// </summary>
        public double TimeCounter { get; set; }

        /// <summary>
        /// total numeber of frames for animation
        /// </summary>
        public int TotalFrames { get; set; }
        
        //This overload of Draw needs:
        //texture, position, source rectangle,
        //color, rotation, origin position,
        //scale, SpriteEffects, and layer depth

        //texture is obtained through entity's texture
        //position is obtained through entity's rectangle

        /// <summary>
        /// source rectangle on sprite sheet
        /// </summary>
        public Rectangle SourceRectangle { get; set; }

        /// <summary>
        /// color of sprite
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// rotation of the sprite
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// origin of the source rectangle
        /// </summary>
        public Vector2 SourceOrigin { get; set; }

        /// <summary>
        /// scale of the sprite obtained from rectangle
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// sprite effect (flipped vertically, horizontally, etc.)
        /// </summary>
        public SpriteEffects SpriteEffect { get; set; }


        /// <summary> 
        /// if set to 1 objects will be drawn in order
        /// depending on overload of draw, it is possible to sort what is drawn
        /// </summary>
        public float LayerDepth { get; set; }

        /// <summary>
        /// instantiates animatable entity
        /// </summary>
        /// <param name="hitbox">hitbox and location</param>
        /// <param name="texture">texture of the entity</param>
        /// <param name="fPS">how many frames one image lasts for</param>
        /// <param name="sourceRectangle">source rectangle on sprite sheet</param>
        /// <param name="color">color of the sprite to be drawn</param>
        /// <param name="rotation">rotation of the sprite</param>
        /// <param name="sourceOrigin">location of origin for source rectangle</param>
        /// <param name="scale">scale of the sprite</param>
        public Animatable(Rectangle hitbox, 
                          Texture2D texture, 
                          GameTime gameTime,
                          double fPS,  
                          Rectangle sourceRectangle, 
                          Color color, float rotation, 
                          Vector2 sourceOrigin, 
                          float scale,
                          float layerDepth)

        :base(hitbox, texture, gameTime)
        {
            CurrentFrame = 0;
            FPS = fPS;
            SecondsPerFrame = 1.0f / FPS;
            TimeCounter = 0;
            TotalFrames = 1;

            SourceRectangle = sourceRectangle;
            Color = color;
            Rotation = rotation;
            SourceOrigin = sourceOrigin;
            Scale = scale;
            SpriteEffect = SpriteEffects.None;
            LayerDepth = 1.0f;
        }

        /// <summary>
        /// draws the sprite with specified properties
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, new Vector2(Hitbox.X, Hitbox.Y), 
                                         SourceRectangle, Color, 
                                         Rotation, 
                                         SourceOrigin, Scale, 
                                         SpriteEffect, LayerDepth);
            UpdateAnimation(GameTime);
        }



        /// <summary>
        /// Updates the animation time
        /// </summary>
        /// <param name="gameTime">Game time information</param>
        private void UpdateAnimation(GameTime gameTime)
        {
            // Add to the time counter (need TOTALSECONDS here)
            TimeCounter += gameTime.ElapsedGameTime.TotalSeconds;

            // Has enough time gone by to actually flip frames?
            if (TimeCounter >= TimeCounter)
            {
                // Update the frame and wrap
                CurrentFrame++;
                if (CurrentFrame >= TotalFrames) CurrentFrame = 1;

                // Remove one "frame" worth of time
                TimeCounter -= SecondsPerFrame;
            }
        }
    }
}
