using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame
{
    // Joshua Smith
    //
    // I mean, it's the player class. It moves, shoots, gets shot, dies, and I guess depending on the 
    // difficulty of our game, it wins sometimes.
    internal class Player : Entity
    {
        private int minSpeed;
        private int currentSpeed;
        private int dashSpeed;
        private bool dashing;
        private Rectangle hitboxTemp;
        private KeyboardState preDash;

        // I will organize this later.
        
        /// <summary>
        /// This is the amount of health that the player has.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// I mean realistically we only call this once, just to create our player at the start of the game.
        /// </summary>
        /// <param name="hitbox"> The rectangle that defines where the player is, and where they can be injured. </param>
        /// <param name="texture"> The texture used to show what our player looks like. </param>
        public Player(Rectangle hitbox, Texture2D texture) : base(hitbox, texture)
        {
            // I'm only setting the health to 100 as a default value. We can come back and change this if we need to adjust it later.
            Health = 100;
            minSpeed = 5;
            currentSpeed = minSpeed;
            dashSpeed = 7;
            
            Hitbox = hitbox;
            Texture = texture;
        }

        /// <summary>
        /// This gets called every frame. It's used to see when other methods should be called.
        /// </summary>
        /// <param name="gameTime"> The amount of time spent in the game. </param>
        public override void Update(GameTime gameTime)
        {
            // Handles the movement of the player. All of this is run if they're not currently dashing.
            if (!dashing)
            {
                if (InputManager.IsKeyDown(Keys.W)) { hitboxTemp.Y -= currentSpeed; Hitbox = hitboxTemp; }
                if (InputManager.IsKeyDown(Keys.A)) { hitboxTemp.X -= currentSpeed; Hitbox = hitboxTemp; }
                if (InputManager.IsKeyDown(Keys.S)) { hitboxTemp.Y += currentSpeed; Hitbox = hitboxTemp; }
                if (InputManager.IsKeyDown(Keys.D)) { hitboxTemp.X += currentSpeed; Hitbox = hitboxTemp; }

                if (InputManager.IsKeyDown(Keys.LeftShift)) { preDash = Keyboard.GetState(); dashing = true; }
            }
            else
            {
                Dash();
            }
        }

        /// <summary>
        /// This is going to be called at the end of a game, to reset the various aspects of a player.
        /// </summary>
        public void ResetPlayer()
        {
            Health = 20;
        }

        /// <summary>
        /// The player's form of attacking. Creates bullet objects. That's essentially it.
        /// </summary>
        public void Shoot()
        {
            // Can't really implement this without InputManager and Projectile.
        }

        /// <summary>
        /// Dashes towards the mouse, and heals health for each bullet we hit during said dash.
        /// </summary>
        public void Dash()
        {
            
        }
    }
}
