﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Railgun.RailgunGame.Util;
using Railgun.RailgunGame.Tilemapping;

// Joshua Smith
// 03/06/2023
//
// I mean, it's the player class. It moves, shoots, gets shot, dies, and I guess depending on the 
// difficulty of our game, it wins sometimes.

namespace Railgun.RailgunGame
{
    /// <summary>
    /// Manages the player and all the related data
    /// </summary>
    internal class Player : Entity
    {
        private int speed;
        private int dashSpeed;
        
        private KeyboardState preDash;

        private Texture2D activeBullet;
        private Animation notActiveBullet;
        private Animation playerIdle;
        private Animation playerRun;
        private Animation playerDeath;

        // I will organize this later.
        
        /// <summary>
        /// A property to see if the player is currently dashing.
        /// </summary>
        public bool Dashing { get; set; }

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
        public int MaxAmmo { get; set; } // TODO: can this be made get only

        /// <summary>
        /// This is the amount of time before the dash is available again.
        /// </summary>
        public double DashCooldown { get; set; }

        /// <summary>
        /// This is the amount of time before the player can shoot again.
        /// </summary>
        public double ShootCooldown { get; set; }

        /// <summary>
        /// The player is invincible for this amount of time after taking damage.
        /// </summary>
        public double DamageCooldown { get; set; }

        /// <summary>
        /// The amount of time the player has been dashing for.
        /// </summary>
        public double DashTime { get; set; }

        /// <summary>
        /// The previous position of the player.
        /// </summary>
        public Vector2 prevPos { get; set; }

        /// <summary>
        /// This is where the player's bullets are stored.
        /// </summary>
        public List<Projectile> PlayerBullets { get; private set; } // TODO: can this be made get only

        /// <summary>
        /// I mean realistically we only call this once, just to create our player at the start of the game.
        /// </summary>
        /// <param name="hitbox"> The rectangle that defines where the player is, and where they can be injured. </param>
        /// <param name="playerIdle">Player's idle animation</param>
        /// <param name="playerRun">Player's run animation</param>
        /// <param name="playerDeath">Player's death animation</param>
        /// <param name="activeBullet">Texture of the bullet while it is active</param>
        /// <param name="notActiveBullet">Animation of bullets right after it collides with something</param>
        public Player(
            Rectangle hitbox, 
            Animation playerIdle, 
            Animation playerRun, 
            Animation playerDeath, 
            Texture2D activeBullet, 
            Animation notActiveBullet) 
            : base(hitbox)
        {
            // I'm only setting the health to 100 as a default value. We can come back and change this if we need to adjust it later.
            Health = 100;
            MaxHealth = Health;
            speed = 6;
            dashSpeed = 15;
            Ammo = 24;
            MaxAmmo = 24;

            DashCooldown = 0.0;
            ShootCooldown = 0.15;
            DamageCooldown = 0.0;
            Dashing = false;
            DashTime = 0.0;

            this.playerIdle = playerIdle;
            this.playerRun = playerRun;
            this.playerDeath = playerDeath;

            this.activeBullet = activeBullet;
            this.notActiveBullet = notActiveBullet;
            
            Hitbox = hitbox;
            PlayerBullets = new List<Projectile>(10);
        }

        /// <summary>
        /// Creates a player with the default animations
        /// </summary>
        /// <param name="hitbox">The hitbox of this player</param>
        /// <param name="activeBullet">The active bullet texture</param>
        public Player(Rectangle hitbox, Texture2D activeBullet)
            : this(hitbox, VisualManager.Instance.PlayerIdle,
                VisualManager.Instance.PlayerMove,
                VisualManager.Instance.PlayerDeath, activeBullet,
                VisualManager.Instance.BulletCollide) { }

        /// <summary>
        /// This gets called every frame. It's used to see when other methods should be called.
        /// </summary>
        /// <param name="gameTime"> The amount of time spent in the game. </param>
        public override void Update(GameTime gameTime, bool canHeal)
        {
            // Adjusts the cooldown on dashing accordingly.
            if (DashCooldown > 0.0)
            {
                DashCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            // Adjusts the cooldown on shooting accordingly.
            if (ShootCooldown > 0.0)
            {
                ShootCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            // Adjusts the cooldown on damage accordingly.
            if (DamageCooldown > 0.0)
            {
                DamageCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }

            // This stores the previous position of the player. It's used for checking whether or not to do the idle animation.
            prevPos = new Vector2(Hitbox.X, Hitbox.Y); 

            // Handles the movement of the player. All of this is run if they're not currently dashing.
            if (!Dashing)
            {
                InputManager.UpdateInputState();

                Rectangle hitbox = Hitbox;

                if (InputManager.IsKeyDown(Keys.W) || InputManager.IsKeyDown(Keys.Up)) { hitbox.Y -= speed; }
                if (InputManager.IsKeyDown(Keys.A) || InputManager.IsKeyDown(Keys.Left)) { hitbox.X -= speed; }
                if (InputManager.IsKeyDown(Keys.S) || InputManager.IsKeyDown(Keys.Down)) { hitbox.Y += speed; }
                if (InputManager.IsKeyDown(Keys.D) || InputManager.IsKeyDown(Keys.Right)) { hitbox.X += speed; }

                hitbox = WorldManager.Instance.ResolveCollisions(hitbox);

                Hitbox = hitbox;

                if (InputManager.IsButtonDown(MouseButtons.Left) && ShootCooldown <= 0.0 && Ammo > 0) { Shoot(); }
                if (InputManager.IsButtonDown(MouseButtons.Right) && Ammo <= 0 && canHeal) { Reload(); }

                if ((InputManager.IsKeyDown(Keys.LeftShift) 
                    || InputManager.IsKeyDown(Keys.Space)) &&
                    DashCooldown <= 0.0)
                {
                    preDash = Keyboard.GetState(); Dashing = true;
                }
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
            Ammo = 24;
            ShootCooldown = 2.5;
            playerDeath.CurrentFrame = 0;

            Hitbox = new Rectangle(0, 0, 100, 100);
        }

        /// <summary>
        /// The player's form of attacking. Creates bullet objects. That's essentially it.
        /// </summary>
        public void Shoot()
        {
            Ammo--;
            ShootCooldown = 0.1f;

            Vector2 vect = (WorldManager.Instance.GetMouseWorldPosition().ToPoint() - Hitbox.Center).ToVector2() / Vector2.Distance(WorldManager.Instance.GetMouseWorldPosition(), Hitbox.Center.ToVector2());

            PlayerBullets.Add(
                new Projectile(
                    new Rectangle(
                        Hitbox.X + Hitbox.Width / 2 - activeBullet.Width / 2, 
                        Hitbox.Y + Hitbox.Height / 2 - activeBullet.Height / 2, 
                        activeBullet.Width, 
                        activeBullet.Height), 
                    activeBullet, 
                    notActiveBullet.Clone(), 
                    vect * 10.0f, 
                    Color.Red));
        }

        /// <summary>
        /// Dashes in the direction that the player was facing.
        /// </summary>
        public void Dash(GameTime gameTime)
        {
            DashTime += gameTime.ElapsedGameTime.TotalSeconds;

            Rectangle hitbox = Hitbox;

            // This is NOT user input, this is what the directional input of the user was back when they initially started dashing.
            if (preDash.IsKeyDown(Keys.W) || preDash.IsKeyDown(Keys.Up)) { hitbox.Y -= dashSpeed; }
            if (preDash.IsKeyDown(Keys.A) || preDash.IsKeyDown(Keys.Left)) { hitbox.X -= dashSpeed; }
            if (preDash.IsKeyDown(Keys.S) || preDash.IsKeyDown(Keys.Down)) { hitbox.Y += dashSpeed; }
            if (preDash.IsKeyDown(Keys.D) || preDash.IsKeyDown(Keys.Right)) { hitbox.X += dashSpeed; }

            hitbox = WorldManager.Instance.ResolveCollisions(hitbox);

            Hitbox = hitbox;

            // This is the total duration of the dash. We can edit this number later.
            if (DashTime >= .35) 
            {
                DashTime = 0.0;
                DashCooldown = 1.0;
                Dashing = false;
            }
        }

        /// <summary>
        /// This is where the player is drawn. Might not need to edit this but when the animation object is made, I might.
        /// </summary>
        /// <param name="sb"> The spritebatch being drawn with. </param>
        /// <param name="gameTime">Gametime object</param>
        public bool Draw(SpriteBatch sb, GameTime gameTime)
        {
            SpriteEffects effect = SpriteEffects.None;
            if(WorldManager.Instance.GetMouseWorldPosition().X < Hitbox.X + Hitbox.Width / 2)
            {
                effect = SpriteEffects.FlipHorizontally;
            }

            if (Health <= 0)
            {
                return playerDeath.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.Gray, effect); ;
            }
            
            else if (prevPos.X == Hitbox.X && prevPos.Y == Hitbox.Y)
            {
                if (DamageCooldown <= 0.0)
                {
                    playerIdle.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, effect);
                }
                else
                {
                    playerIdle.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.Gray, effect);
                }
            }
            
            else
            {
                if(!Dashing)
                {
                    if(DamageCooldown <= 0.0)
                    {
                        playerRun.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, effect);
                    }
                    else
                    {
                        playerRun.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.Gray, effect);
                    }
                }
                else
                {
                    playerRun.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.Blue, effect);
                }
            }
            return false;
        }

        /// <summary>
        /// This method damages the player. It also heals them if they're dashing.
        /// </summary>
        /// <param name="damage"> The amount of damage that this specific projectile will deal. </param>
        public void Damage(int damage)
        {
            if(!Dashing)
            {
                Health -= damage;
                DamageCooldown = 2.5;
            }
            else
            {
                // If the player is dashing, they heal this amount per bullet. This can be adjusted during playtesting.
                Health += damage;
                if(Health > 100)
                {
                    Health = 100;
                }
            }
        }

        /// <summary>
        /// This refills the player's ammo. It also hurts them.
        /// </summary>
        public void Reload()
        {
            // The player takes 20 damage for reloading. This can be adjusted later.
            Health -= 20; 
            Ammo = MaxAmmo;
        }
    }                                        
}                                            
