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
    // 03/06/2023
    //
    // I mean, it's the player class. It moves, shoots, gets shot, dies, and I guess depending on the 
    // difficulty of our game, it wins sometimes.
    internal class Player : Entity
    {
        private int speed;
        private int dashSpeed;
        private bool dashing;
        
        private Rectangle hitboxTemp;
        private KeyboardState preDash;

        private Texture2D activeBullet;
        private Animation notActiveBullet;

        // I will organize this later.
        
        /// <summary>
        /// This is the amount of health that the player has.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// This is the amount of the bullets that the player has.
        /// </summary>
        public int Ammo { get; set; }

        /// <summary>
        /// This is the amount of time before the dash is available again.
        /// </summary>
        public double DashCooldown { get; set; }

        /// <summary>
        /// This is the amount of time before the player can shoot again.
        /// </summary>
        public double ShootCooldown { get; set; }

        /// <summary>
        /// The amount of time the player has been dashing for.
        /// </summary>
        public double DashTime { get; set; }

        /// <summary>
        /// This is where the player's bullets are stored.
        /// </summary>
        public List<Projectile> PlayerBullets { get; private set; }

        /// <summary>
        /// I mean realistically we only call this once, just to create our player at the start of the game.
        /// </summary>
        /// <param name="hitbox"> The rectangle that defines where the player is, and where they can be injured. </param>
        /// <param name="texture"> The texture used to show what our player looks like. </param>
        public Player(Rectangle hitbox, Texture2D texture, Texture2D activeBullet, Animation notActiveBullet) : base(hitbox, texture)
        {
            // I'm only setting the health to 100 as a default value. We can come back and change this if we need to adjust it later.
            Health = 100;
            speed = 5;
            dashSpeed = 10;
            Ammo = 8;

            DashCooldown = 0.0;
            ShootCooldown = 2.5;
            dashing = false;
            DashTime = 0.0;

            this.activeBullet = activeBullet;
            this.notActiveBullet = notActiveBullet;
            
            Hitbox = hitbox;
            hitboxTemp = hitbox;
            Texture = texture;
            PlayerBullets = new List<Projectile>(10);
        }

        /// <summary>
        /// This gets called every frame. It's used to see when other methods should be called.
        /// </summary>
        /// <param name="gameTime"> The amount of time spent in the game. </param>
        public override void Update(GameTime gameTime)
        {
            if(DashCooldown > 0.0)
            {
                DashCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            } // Adjusts the cooldown on dashing accordingly.
            if(ShootCooldown > 0.0)
            {
                ShootCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            } // Adjusts the cooldown on shooting accordingly.

            // Handles the movement of the player. All of this is run if they're not currently dashing.
            if (!dashing)
            {
                InputManager.UpdateInputState();

                if (InputManager.IsKeyDown(Keys.W)) { hitboxTemp.Y -= speed; Hitbox = hitboxTemp; }
                if (InputManager.IsKeyDown(Keys.A)) { hitboxTemp.X -= speed; Hitbox = hitboxTemp; }
                if (InputManager.IsKeyDown(Keys.S)) { hitboxTemp.Y += speed; Hitbox = hitboxTemp; }
                if (InputManager.IsKeyDown(Keys.D)) { hitboxTemp.X += speed; Hitbox = hitboxTemp; }

                if (InputManager.IsButtonDown(MouseButtons.Left) && ShootCooldown <= 0.0 && Ammo > 0) { Shoot(gameTime); }
                if (InputManager.IsButtonDown(MouseButtons.Right) && Ammo <= 0) { Reload(); }

                if (InputManager.IsKeyDown(Keys.LeftShift) && DashCooldown <= 0.0) { preDash = Keyboard.GetState(); dashing = true; }
            }
            else
            {
                Dash(gameTime);
            }
        }

        /// <summary>
        /// This is going to be called at the end of a game, to reset the various aspects of a player.
        /// </summary>
        public void ResetPlayer()
        {
            Health = 100;
            Ammo = 8;
            ShootCooldown = 2.5;
        }

        /// <summary>
        /// The player's form of attacking. Creates bullet objects. That's essentially it.
        /// </summary>
        public void Shoot(GameTime gameTime)
        {
            int xVelocity;
            Ammo--;
            ShootCooldown = 2.5;

            if(InputManager.MouseState.X > 100)
            {
                xVelocity = ((Hitbox.X + (Hitbox.Width / 2)) + 100 - (Hitbox.X + (Hitbox.Width / 2))) / 20;
            }
            else if(InputManager.MouseState.X < 100)
            {
                xVelocity = ((Hitbox.X + (Hitbox.Width / 2)) - 100 - (Hitbox.X + (Hitbox.Width / 2))) / 20;
            }
            else
            {
                xVelocity = (InputManager.MouseState.X - (Hitbox.X + (Hitbox.Width / 2))) / 100;
            }
            int yVelocity = 1;

            PlayerBullets.Add(new Projectile(new Rectangle(Hitbox.X, Hitbox.Y, activeBullet.Width, activeBullet.Height), activeBullet, notActiveBullet, new Vector2(
                xVelocity, 
                yVelocity)));
        }

        /// <summary>
        /// Dashes in the direction that the player was not facing.
        /// </summary>
        public void Dash(GameTime gameTime)
        {
            DashTime += gameTime.ElapsedGameTime.TotalSeconds;

            // This is NOT user input, this is what the directional input of the user was back when they initially started dashing.
            if (preDash.IsKeyDown(Keys.W)) { hitboxTemp.Y -= dashSpeed; Hitbox = hitboxTemp; }
            if (preDash.IsKeyDown(Keys.A)) { hitboxTemp.X -= dashSpeed; Hitbox = hitboxTemp; }
            if (preDash.IsKeyDown(Keys.S)) { hitboxTemp.Y += dashSpeed; Hitbox = hitboxTemp; }
            if (preDash.IsKeyDown(Keys.D)) { hitboxTemp.X += dashSpeed; Hitbox = hitboxTemp; }

            // This is the total duration of the dash. We can edit this number later.
            if(DashTime >= .75) 
            {
                DashTime = 0.0;
                DashCooldown = 10.0;
                dashing = false;
            }
        }        
        
        /// <summary>
        /// This is where the player is drawn. Might not need to edit this but when the animation object is made, I might.
        /// </summary>
        /// <param name="sb"> The spritebatch being drawn with. </param>
        public void Draw(SpriteBatch sb)
        {
            if (!dashing)
            {
                sb.Draw(Texture, Hitbox, Color.White);
            }
            else
            {
                sb.Draw(Texture, Hitbox, Color.Blue);
            }
        }

        /// <summary>
        /// This method damages the player. It also heals them if they're dashing.
        /// </summary>
        /// <param name="damage"> The amount of damage that this specific projectile will deal. </param>
        public void Damage(int damage)
        {
            if (!dashing)
            {
                Health -= damage;
            }
            else
            {
                // If the player is dashing, they heal this amount per bullet. This can be adjusted during playtesting.
                Health += 5;
            }
        }

        /// <summary>
        /// This refills the player's ammo. It also hurts them.
        /// </summary>
        public void Reload()
        {
            Damage(20); // The player takes 20 damage for reloading. This can be adjusted later.
            Ammo = 8;
        }
    }                                        
}                                            
