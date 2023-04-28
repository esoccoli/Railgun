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
using System.Linq.Expressions;

//Copied GasMan, modified by Igor to be a stationary enemy 
//Enemy that walks away from the player
namespace Railgun.RailgunGame
{
    internal class Turret : Enemy
    {
        public enum TurretState
        {
            Shoot,
            Death
        }

        //private Vector2 velocity;
        private Texture2D activeBullet;
        private Animation notActiveBullet;
        //private double SecondsPerState;
        //private double TimeCounter;
        private double bulletCooldown;
        private double timeSinceShot;

        /// <summary>
        /// animation to play when enemy is shooting
        /// </summary>
        public Animation Shooting { get; set; }

        /// <summary>
        /// current state of the enemy
        /// </summary>
        public TurretState CurrentState { get; private set; }

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
        public Turret(Animation death, Rectangle hitbox, Animation shoot, Texture2D activeBullet, Animation notActiveBullet) : base(shoot, death, hitbox)
        {
            Health = 40;
            Hitbox = hitbox;
            //SecondsPerState = 1;
            //TimeCounter = 0;

            this.activeBullet = activeBullet;
            this.notActiveBullet = notActiveBullet;
            CurrentState = TurretState.Shoot;
            Shooting = shoot;
            bulletCooldown = .5;
            timeSinceShot = 0;
            EnemyBullets = new List<Projectile>();
        }

        public Turret(Rectangle hitbox)
            : this(
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
        /// /// <param name="playerPos">current position of the player</param>
        public override void Update(GameTime gameTime, Point playerPos)
        {
            if (Health <= 0)
            {
                CurrentState = TurretState.Death;
            }
            switch (CurrentState)
            {
                case TurretState.Shoot:
                    timeSinceShot += gameTime.ElapsedGameTime.TotalSeconds;
                    if (timeSinceShot >= bulletCooldown)
                    {
                        Shoot(playerPos);
                        timeSinceShot = 0;
                    }
                    //TimeCounter += gameTime.ElapsedGameTime.TotalSeconds;
                    break;

                case TurretState.Death:
                    break;
            }
        }

        /// <summary>
        /// draws thre enemy in the proper state after update
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
                case TurretState.Shoot:
                    if (playerPos.X <= Hitbox.Center.X)
                    {
                        Shooting.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.Yellow, SpriteEffects.FlipHorizontally);;
                    }
                    else
                    {
                        Shooting.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.Yellow, SpriteEffects.None);
                    }
                    return false;


                case TurretState.Death:
                    return Death.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.PeachPuff, SpriteEffects.None);
            }
            return false;
        }


        /// <summary>
        /// Shoots a bullet at the player's position
        /// </summary>
        /// <param name="playerPos">player's position</param>
        public override void Shoot(Point playerPos)
        {

            Vector2 vect = (playerPos - Hitbox.Center).ToVector2() / Vector2.Distance(playerPos.ToVector2(), Hitbox.Center.ToVector2());
            EnemyProjManager.Instance.Projectiles.Add(new Projectile(new Rectangle(Hitbox.X + (Hitbox.Width / 2) - (activeBullet.Width / 2), Hitbox.Y + (Hitbox.Height / 2) - (activeBullet.Height / 2),
                activeBullet.Width, activeBullet.Height), activeBullet, notActiveBullet.Clone(), vect * 10.0f, Color.Yellow));
            EnemyProjManager.Instance.Projectiles.Add(new Projectile(new Rectangle(Hitbox.X + (Hitbox.Width / 2) - (activeBullet.Width / 2), Hitbox.Y + (Hitbox.Height / 2) - (activeBullet.Height / 2),
                activeBullet.Width, activeBullet.Height), activeBullet, notActiveBullet.Clone(), vect * 8.0f, Color.Yellow));
            EnemyProjManager.Instance.Projectiles.Add(new Projectile(new Rectangle(Hitbox.X + (Hitbox.Width / 2) - (activeBullet.Width / 2), Hitbox.Y + (Hitbox.Height / 2) - (activeBullet.Height / 2),
                activeBullet.Width, activeBullet.Height), activeBullet, notActiveBullet.Clone(), vect * 6.0f, Color.Yellow));

        }

        /// <summary>
        /// Moves the enemy away from the player
        /// </summary>
        /// <param name="playerPos">current position of the player</param>
        public override void Walk(Point playerPos)
        {

        }
    }
}
