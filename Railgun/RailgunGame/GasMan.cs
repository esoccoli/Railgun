﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Railgun.RailgunGame.Util;
using Railgun.RailgunGame.Tilemapping;

// Nathan McAndrew
// Enemy that walks away from the player
namespace Railgun.RailgunGame
{
    /// <summary>
    /// Manages the gas man enemy and related data
    /// </summary>
    internal class GasMan : Enemy
    {
        /// <summary>
        /// Possible states that the gas man enemy can be in
        /// </summary>
        public enum GasState
        {
            Walk,
            Shoot,
            Death
        }

        private Vector2 velocity;
        private Texture2D activeBullet;
        private Animation notActiveBullet;
        private double SecondsPerState;
        private double TimeCounter;
        private double bulletCooldown;
        private double timeSinceShot;

        /// <summary>
        /// Animation to play when enemy is shooting
        /// </summary>
        public Animation Shooting { get; set; }

        /// <summary>
        /// current state of the enemy
        /// </summary>
        public GasState CurrentState { get; private set; }

        /// <summary>
        /// list of all projectiles fired by the enemy
        /// </summary>
        public List<Projectile> EnemyBullets { get; set; }

        /// <summary>
        /// creates an instance of an enemy that shoots at the player and runs away
        /// </summary>
        /// <param name="move">walk animation</param>
        /// <param name="death">death animation</param>
        /// <param name="hitbox">hitbox</param>
        /// <param name="shoot">shooting animation</param>
        /// <param name="activeBullet">Texture of the bullet while it is active</param>
        /// <param name="notActiveBullet">Animation of the bullet right after it collides with something</param>
        public GasMan(
            Animation move, 
            Animation death, 
            Rectangle hitbox, 
            Animation shoot, 
            Texture2D activeBullet, 
            Animation notActiveBullet) 
            : base(move, death, hitbox)
        {
            Health = 40;
            Hitbox = hitbox;
            SecondsPerState = 4;
            TimeCounter = 0;

            this.activeBullet = activeBullet;
            this.notActiveBullet = notActiveBullet;
            CurrentState = GasState.Walk;
            Shooting = shoot;
            bulletCooldown = .25;
            timeSinceShot = 0;
            EnemyBullets = new List<Projectile>();
        }

        public GasMan(Rectangle hitbox)
            : this(VisualManager.Instance.GasManMove.Clone(),
                VisualManager.Instance.GasManDeath.Clone(),
                hitbox,
                VisualManager.Instance.GasManShoot.Clone(),
                VisualManager.Instance.BulletTexture,
                VisualManager.Instance.BulletCollide.Clone())
        { }

        /// <summary>
        /// Updates the state of the enemy
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        /// <param name="playerPos">current position of the player</param>
        public override void Update(GameTime gameTime, Point playerPos)
        {
            if (Health <= 0)
            {
                CurrentState = GasState.Death;
            }
            
            switch (CurrentState)
            {
                case GasState.Walk:
                    
                    Walk(playerPos);
                    TimeCounter += gameTime.ElapsedGameTime.TotalSeconds;
                    
                    if (TimeCounter >= SecondsPerState)
                    {
                        CurrentState = GasState.Shoot;
                        TimeCounter = 0;
                    }
                    break;

                case GasState.Shoot:
                    
                    timeSinceShot += gameTime.ElapsedGameTime.TotalSeconds;
                    
                    if (timeSinceShot >= bulletCooldown)
                    {
                        Shoot(playerPos);
                        timeSinceShot = 0;
                    }
                    
                    TimeCounter += gameTime.ElapsedGameTime.TotalSeconds;
                    if (TimeCounter >= SecondsPerState)
                    {
                        CurrentState = GasState.Walk;
                        TimeCounter = 0;
                    }
                    break;

                case GasState.Death:
                    break;
            }
        }

        /// <summary>
        /// Draws the enemy in the proper state after update
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        /// <param name="gameTime">gameTime</param>
        /// <param name="playerPos">position of the player</param>
        /// <returns>Walk: false
        /// Shoot: false
        /// Death: True if the last frame of the animation has been reached</returns>
        public override bool Draw(SpriteBatch sb, GameTime gameTime, Point playerPos)
        {

            switch (CurrentState)
            {
                case GasState.Walk:
                    
                    if (playerPos.X <= Hitbox.Center.X)
                    {
                        Move.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.FlipHorizontally);
                    }
                    else
                    {
                        Move.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.None);
                    }
                    return false;


                case GasState.Shoot:
                    
                    if (playerPos.X <= Hitbox.Center.X)
                    {
                        Shooting.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.FlipHorizontally);
                    }
                    else
                    {
                        Shooting.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.None);
                    }
                    return false;


                case GasState.Death:
                    return Death.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.PeachPuff, SpriteEffects.None);
            }
            
            return false;
        }


        /// <summary>
        /// Shoots a bullet at the player's position
        /// </summary>
        /// <param name="playerPos">player's position</param>
        public virtual void Shoot(Point playerPos)
        {

            Vector2 vect = (playerPos - Hitbox.Center).ToVector2() / Vector2.Distance(playerPos.ToVector2(), Hitbox.Center.ToVector2());
            EnemyProjManager.Instance.Projectiles.Add(
                new Projectile(
                    new Rectangle(
                        Hitbox.X + Hitbox.Width / 2 - activeBullet.Width / 2, 
                        Hitbox.Y + Hitbox.Height / 2 - activeBullet.Height / 2, 
                        activeBullet.Width, 
                        activeBullet.Height), 
                    activeBullet, 
                    notActiveBullet.Clone(), 
                    vect * 10.0f, 
                    Color.Blue));
        }

        /// <summary>
        /// Moves the enemy away from the player
        /// </summary>
        /// <param name="playerPos">current position of the player</param>
        public override void Walk(Point playerPos)
        {
            Rectangle hitboxTemp = Hitbox;
            float distance = Vector2.Distance(playerPos.ToVector2(), Hitbox.Center.ToVector2());

            // Prevents "teleportation"
            if (distance == 0)
            {
                distance = 1;
            }

            velocity = (playerPos - Hitbox.Center).ToVector2() / distance * 4;

            hitboxTemp.X -= (int)velocity.X;
            hitboxTemp.Y -= (int)velocity.Y;

            hitboxTemp = WorldManager.Instance.ResolveCollisions(hitboxTemp);
            Hitbox = hitboxTemp;
        }
    }
}
