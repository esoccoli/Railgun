﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Nathan McAndrew
//Class responsible for animating all objects
namespace Railgun.RailgunGame
{
    public class Animation
    {

        // animation elements

        /// <summary>
        /// current columns in a row of sprite sheet
        /// </summary>
        public int CurrentFrame { get; set; }

        /// <summary>
        /// time one frame lasts for
        /// </summary>
        public double SecondsPerFrame { get; }

        /// <summary>
        /// time since image was changed
        /// aka "delta time" or "Elapsed time"
        /// </summary>
        public double TimeCounter { get; set; }

        /// <summary>
        /// total numeber of frames for animation
        /// </summary>
        public int TotalFrames { get; }

        /// <summary>
        /// number of columns on the spritesheet
        /// </summary>
        public int NumColumns { get; }

        /// <summary>
        /// number of rows on the spritesheet
        /// </summary>
        public int NumRows { get; }
        
        // This overload of Draw needs:
        // texture, position, source rectangle,
        // color, origin position, scale,
        // SpriteEffects, and layer depth

        /// <summary>
        /// Textrure for the animation
        /// </summary>
        public Texture2D SpriteSheet { get; }

        /// <summary>
        /// source rectangle on sprite sheet
        /// </summary>
        public Rectangle SourceRectangle { get; set; }

        /// <summary>
        /// color of sprite
        /// </summary>
        public Color Color { get; }

/*
        /// <summary>
        /// origin of the source rectangle
        /// </summary>
        public Vector2 SourceOrigin { get; set; }
*/

        /// <summary>
        /// scale of the sprite obtained from rectangle
        /// </summary>S
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
        /// width of each frame (on spritesheet)
        /// </summary>
        public int FrameWidth { get; }

        /// <summary>
        /// height of each frame (on spritesheet)
        /// </summary>
        public int FrameHeight { get; }

        /// <summary>
        /// Instantiates an animation object with the specified
        /// texture, rows, columns, framerate, and color
        /// </summary>
        /// <param name="spriteSheet">Texture to animate</param>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        /// <param name="framesPerSecond">Number of frames per second in the animation</param>
        /// <param name="color">Tint color for the texture being drawn</param>
        public Animation(Texture2D spriteSheet, int rows, int columns, float framesPerSecond, Color color) 
        {
            SpriteSheet = spriteSheet;
            CurrentFrame = 0;
            SecondsPerFrame = 1.0f / framesPerSecond;
            TimeCounter = 0;
            NumRows = rows;
            NumColumns = columns;
            TotalFrames = NumRows * NumColumns;

            FrameWidth = SpriteSheet.Width / NumColumns;
            FrameHeight= SpriteSheet.Height / NumRows;

            Scale = 1.0f;
            SpriteEffect = SpriteEffects.None;
            LayerDepth = 1.0f;

            Color = color;
        }

        /// <summary>
        /// Instantiates an animation object with the specified
        /// texture, rows, columns, framerate, and a default white color
        /// </summary>
        /// <param name="spriteSheet">Sprite sheet file for the animation</param>
        /// <param name="rows">Number of rows in the spritesheet</param>
        /// <param name="columns">Number of columns in the spritesheet</param>
        /// <param name="framesPerSecond">Speed of the animation</param>
        public Animation(Texture2D spriteSheet, int rows, int columns, float framesPerSecond) 
        :this(spriteSheet, rows, columns, framesPerSecond, Color.White){ }

        /// <summary>
        /// draws the sprite with specified properties
        /// </summary>
        /// <param name="sb">Spritebatch object</param>
        /// <param name="gameTime">Gametime object</param>
        /// <param name="position">Position of the texture</param>
        /// <param name="tint">Tint color of the texture when drawn</param>
        /// <param name="effect">Direction the texture is flipped in</param>
        /// <returns> Whether or not the animation has reached its final frame.</returns>
        public bool Draw(SpriteBatch sb, GameTime gameTime, Vector2 position, Color tint, SpriteEffects effect)
        {
            UpdateAnimation(gameTime);

            int row = CurrentFrame / NumColumns;
            int col = CurrentFrame % NumColumns;

            SourceRectangle = new Rectangle(FrameWidth * col, FrameHeight * row, FrameWidth, FrameHeight);

            // Rectangle on screen to be drawn to
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, 100, 100);

            sb.Draw(SpriteSheet, destination, SourceRectangle, tint, 0.0f, Vector2.Zero, effect, 0.0f);
            
            return CurrentFrame == TotalFrames -1;
        }

        /// <summary>
        /// Draws the sprite with the specified properties, as well as the color stored by the animation
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        /// <param name="gameTime">gameRime</param>
        /// <param name="position">position to move bounding box to</param>
        /// <param name="effect">is the sprite flipped?</param>
        /// <returns>true if the animation is at the final frame, false otherwise</returns>
        public bool Draw(SpriteBatch sb, GameTime gameTime, Vector2 position, SpriteEffects effect)
        {
            return Draw(sb, gameTime, position, Color, effect);
        }


        /// <summary>
        /// Updates the current frame for the animation
        /// </summary>
        /// <param name="gameTime">Game time information</param>
        private void UpdateAnimation(GameTime gameTime)
        {
            // Add to the time counter (need TOTALSECONDS here)
            TimeCounter += gameTime.ElapsedGameTime.TotalSeconds;

            // Has enough time gone by to actually flip frames?
            if (TimeCounter >= SecondsPerFrame)
            {
                // Update the frame and wrap
                CurrentFrame++;

                // if it is on the last frame
                if (CurrentFrame >= TotalFrames) 
                {
                    CurrentFrame = 0;
                }

                TimeCounter = 0;
            }
        }

        /// <summary>
        /// clones the current animations
        /// </summary>
        /// <returns>the same animation but with reset values</returns>
        public Animation Clone()
        {
            return new Animation(SpriteSheet, NumRows, NumColumns, (float)( 1.0f / SecondsPerFrame));
        }
    }
}
