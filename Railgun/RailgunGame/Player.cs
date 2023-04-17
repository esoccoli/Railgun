using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railgun.RailgunGame.Util;
using Railgun.RailgunGame.Tilemapping;

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
        
        private KeyboardState preDash;

        private Texture2D activeBullet;
        private Animation notActiveBullet;
        private Animation playerIdle;
        private Animation playerRun;

        // I will organize this later.
        
        /// <summary>
        /// This is the amount of health that the player has.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// The maximum health of the player.
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        /// This is the amount of the bullets that the player has.
        /// </summary>
        public int Ammo { get; set; }

        /// <summary>
        /// This is the max amount of bullets that the player can hold.
        /// </summary>
        public int MaxAmmo { get; set; }

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

        public Vector2 prevPos { get; set; }

        /// <summary>
        /// This is where the player's bullets are stored.
        /// </summary>
        public List<Projectile> PlayerBullets { get; private set; }

        /// <summary>
        /// I mean realistically we only call this once, just to create our player at the start of the game.
        /// </summary>
        /// <param name="hitbox"> The rectangle that defines where the player is, and where they can be injured. </param>
        /// <param name="texture"> The texture used to show what our player looks like. </param>
        public Player(Rectangle hitbox, Animation playerIdle, Animation playerRun, Texture2D activeBullet, Animation notActiveBullet) : base(hitbox)
        {
            // I'm only setting the health to 100 as a default value. We can come back and change this if we need to adjust it later.
            Health = 100;
            MaxHealth = Health;
            speed = 5;
            dashSpeed = 10;
            Ammo = 24;
            MaxAmmo = 24;

            DashCooldown = 0.0;
            ShootCooldown = 0.15;
            dashing = false;
            DashTime = 0.0;

            this.playerIdle = playerIdle;
            this.playerRun = playerRun;

            this.activeBullet = activeBullet;
            this.notActiveBullet = notActiveBullet;
            
            Hitbox = hitbox;
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

            prevPos = new Vector2(Hitbox.X, Hitbox.Y); // This stores the previous position of the player. It's used for checking whether or not to do the idle animation.

            // Handles the movement of the player. All of this is run if they're not currently dashing.
            if (!dashing)
            {
                InputManager.UpdateInputState();

                Rectangle hitbox = Hitbox;

                if (InputManager.IsKeyDown(Keys.W)) { hitbox.Y -= speed; }
                if (InputManager.IsKeyDown(Keys.A)) { hitbox.X -= speed; }
                if (InputManager.IsKeyDown(Keys.S)) { hitbox.Y += speed; }
                if (InputManager.IsKeyDown(Keys.D)) { hitbox.X += speed; }

                hitbox = WorldManager.Instance.CurrentMap.ResolveCollisions(hitbox);

                Hitbox = hitbox;

                if (InputManager.IsButtonDown(MouseButtons.Left) && ShootCooldown <= 0.0 && Ammo > 0) { Shoot(); }
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
        public void Shoot()
        {
            Ammo--;
            ShootCooldown = 0.1f;

            Vector2 vect = (InputManager.MouseState.Position - Hitbox.Center).ToVector2() / Vector2.Distance(InputManager.MouseState.Position.ToVector2(), Hitbox.Center.ToVector2());

            PlayerBullets.Add(new Projectile(new Rectangle(Hitbox.X + (Hitbox.Width / 2) - (activeBullet.Width / 2), Hitbox.Y + (Hitbox.Height / 2) - (activeBullet.Height / 2), activeBullet.Width, activeBullet.Height), activeBullet, notActiveBullet, vect * 10.0f));
        }

        /// <summary>
        /// Dashes in the direction that the player was facing.
        /// </summary>
        public void Dash(GameTime gameTime)
        {
            DashTime += gameTime.ElapsedGameTime.TotalSeconds;

            Rectangle hitbox = Hitbox;

            // This is NOT user input, this is what the directional input of the user was back when they initially started dashing.
            if (preDash.IsKeyDown(Keys.W)) { hitbox.Y -= dashSpeed; }
            if (preDash.IsKeyDown(Keys.A)) { hitbox.X -= dashSpeed; }
            if (preDash.IsKeyDown(Keys.S)) { hitbox.Y += dashSpeed; }
            if (preDash.IsKeyDown(Keys.D)) { hitbox.X += dashSpeed; }

            hitbox = WorldManager.Instance.CurrentMap.ResolveCollisions(hitbox);

            Hitbox = hitbox;

            // This is the total duration of the dash. We can edit this number later.
            if(DashTime >= .75) 
            {
                DashTime = 0.0;
                DashCooldown = 3.5;
                dashing = false;
            }
        }        
        
        /// <summary>
        /// This is where the player is drawn. Might not need to edit this but when the animation object is made, I might.
        /// </summary>
        /// <param name="sb"> The spritebatch being drawn with. </param>
        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            SpriteEffects effect = SpriteEffects.None;
            if(InputManager.MouseState.Position.X < Hitbox.X + (Hitbox.Width / 2))
            {
                effect = SpriteEffects.FlipHorizontally;
            }

            if(prevPos.X == Hitbox.X && prevPos.Y == Hitbox.Y)
            {
                playerIdle.Draw(sb, gameTime, new Vector2(Hitbox.X, Hitbox.Y), Color.White, effect);
            }
            else
            {
                if (!dashing)
                {
                    playerRun.Draw(sb, gameTime, new Vector2(Hitbox.X, Hitbox.Y), Color.White, effect);
                }
                else
                {
                    playerRun.Draw(sb, gameTime, new Vector2(Hitbox.X, Hitbox.Y), Color.Blue, effect);
                }
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
            Ammo = MaxAmmo;
        }
    }                                        
}                                            
