using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Railgun.RailgunGame.Tilemapping;

// Nathan McAndrew
// Class for all projectiles in the game
namespace Railgun.RailgunGame
{
    /// <summary>
    /// Manages all of the projectiles in the game
    /// </summary>
    internal class Projectile : Entity
    {
        /// <summary>
        /// possible animation states for projectiles
        /// </summary>
        public enum ProjectileStates
        {
            IsActive,
            HasCollided
        }

        private int halfWidth;
        private int halfHeight;

        /// <summary>
        /// Projectile's X and Y velocities
        /// </summary>
        public Vector2 Velocity { get; set; } // TODO: can this be made get only

        /// <summary>
        /// The current position of the bullet. BOY this has a story behind it...
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// current state of the projectile:
        /// active or has collided
        /// </summary>
        public ProjectileStates CurrentState { get; set; }

        /// <summary>
        /// animation to play when projectile is active
        /// </summary>
        public Texture2D ActiveTexture { get; set; } // TODO: can this be made get only

        /// <summary>
        /// animation to play when projectile collides
        /// </summary>
        public Animation HasCollided { get; set; } // TODO: can this be made get only

        /// <summary>
        /// The color of the bullet.
        /// </summary>
        public Color color { get; set; } // TODO: can this be made get only

        /// <summary>
        /// instantiates a projectile
        /// </summary>
        /// <param name="hitbox">hitbox of projectile</param>
        /// <param name="isActiveTexture">Texture of the projectile while it is active</param>
        /// <param name="hasCollidedAnimation">Animation of the projectile right after it collides with something</param>
        /// <param name="Velocity">Velocity of the projectile</param>
        /// <param name="color">Color of the projectile texture</param>
        public Projectile(
            Rectangle hitbox, 
            Texture2D isActiveTexture,
            Animation hasCollidedAnimation,
            Vector2 Velocity,
            Color color) 
            : base(hitbox)
        {
            this.Velocity = Velocity;
            ActiveTexture = isActiveTexture;
            HasCollided = hasCollidedAnimation;
            Position = Hitbox.Center.ToVector2();
            halfWidth = hitbox.Width / 2;
            halfHeight = hitbox.Height / 2;
            this.color = color;
        }

        /// <summary>
        /// checks if a projectile has collided with an entity
        /// </summary>
        /// <param name="check">entity to check collision with</param>
        public void CheckCollision(Entity check)
        {
            // has hit an entity
            if (check.Hitbox.Intersects(this.Hitbox))
            {
                CurrentState = ProjectileStates.HasCollided;
            }
        }

        /// <summary>
        /// updates the current state and position
        /// of the projectile
        /// </summary>
        /// <param name="gameTime">GameTime</param>
        public void Update(GameTime gameTime)
        {
            switch (CurrentState)
            {
                case ProjectileStates.IsActive:
                    Position += Velocity;
                    Hitbox = new Rectangle((int)(Position.X + Velocity.X) - halfWidth, (int)(Position.Y + Velocity.Y) - halfHeight, Hitbox.Width, Hitbox.Height);
                    break;

                case ProjectileStates.HasCollided:
                    //do nothing
                    break;
            }
            if (WorldManager.Instance.IsColliding(Position))
            {
                CurrentState = ProjectileStates.HasCollided;
            }
        }

        /// <summary>
        /// Draws the projectile with 
        /// the specified properties
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        /// <param name="gameTime">Gametime object</param>
        public bool Draw(SpriteBatch sb, GameTime gameTime)
        {
            switch(CurrentState)
            {
                case ProjectileStates.IsActive:
                    sb.Draw(
                        ActiveTexture, 
                        new Rectangle(
                            (int)(Position.X - ActiveTexture.Width / 2), 
                            (int)(Position.Y - ActiveTexture.Height / 2), 
                            ActiveTexture.Width, 
                            ActiveTexture.Height), 
                        color);
                    
                    break;

                case ProjectileStates.HasCollided:
                    if (HasCollided.CurrentFrame != HasCollided.TotalFrames)
                    {
                        // We need to subtract from Position half the width of the animation rectangle and bullet texture.
                        return HasCollided.Draw(
                            sb, 
                            gameTime, 
                            new Vector2(
                                Position.X - (50 - ActiveTexture.Width /2), 
                                Position.Y - (50 - ActiveTexture.Height / 2)), 
                            Color.White, 
                            SpriteEffects.None);
                    }
                    break;
            }
            return false;
        }
    }
}