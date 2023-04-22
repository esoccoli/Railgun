﻿//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Railgun.RailgunGame.Util;
//using Railgun.RailgunGame.Tilemapping;

////Nathan McAndrew
////Enemy that walks away from the player
//namespace Railgun.RailgunGame
//{
//    internal class GasMan : Enemy
//    {
//        public enum GasState
//        {
//            Walk,
//            Shoot,
//            Death
//        }

//        private Vector2 velocity;
//        private Rectangle hitboxTemp;
//        private Texture2D activeBullet;
//        private Animation notActiveBullet;
//        private int bulletDamage;
//        private double SecondsPerState;
//        private double TimeCounter;

//        public GasState CurrentState { get; private set; }

//        public List<Projectile> EnemyBullets { get; set; }

////        public List<Projectile> EnemyBullets { get; set; }

////        /// <summary>
////        /// animation to play when the enemy fires projectiles at the player
////        /// </summary>
////        public Animation Shooting { get; set; }

//        /// <summary>
//        /// creates an instance of an enemy that shoots at the player and runs away
//        /// </summary>
//        /// <param name="move">walk animation</param>
//        /// <param name="death">death animation</param>
//        /// <param name="hitbox">hitbox</param>
//        /// <param name="shoot">shooting animation</param>
//        public GasMan(Animation move, Animation death, Rectangle hitbox, Animation shoot) : base(move, death, hitbox)
//        {
//            Health = 40;
//            hitboxTemp = Hitbox;
//            SecondsPerState = 4;
//            TimeCounter = 0;

//            CurrentState = GasState.Walk;
//            Shooting = shoot;
//        }

//        /// <summary>
//        /// Updates the state of the enemy
//        /// </summary>
//        /// <param name="gameTime">gameTime</param>
//        /// /// <param name="playerPos">current position of the player</param>
//        public void Update(GameTime gameTime, Point playerPos)
//        {
//            switch (CurrentState)
//            {
//                case GasState.Walk:
//                    Walk(playerPos);
//                    TimeCounter += gameTime.TotalGameTime.TotalMilliseconds;
//                    if (TimeCounter >= SecondsPerState)
//                    {
//                        CurrentState = GasState.Shoot;
//                        TimeCounter = 0;
//                    }
//                    break;

//                case GasState.Shoot:
//                    Shoot(playerPos);
//                    TimeCounter += gameTime.TotalGameTime.TotalMilliseconds;
//                    if (TimeCounter >= SecondsPerState)
//                    {
//                        CurrentState = GasState.Walk;
//                        TimeCounter = 0;
//                    }
//                    break;

//                case GasState.Death:
//                    break;
//            }
//        }

//        /// <summary>
//        /// draws thre enemy in the proper state after update
//        /// </summary>
//        /// <param name="sb">_spritebatch</param>
//        /// <param name="gameTime">gameTime</param>
//        /// <param name="playerPos">position of the player</param>
//        /// <returns>Walk: false
//        /// Shoot: false
//        /// Death: True if the last frame of the animation has been reached</returns>
//        public override bool Draw(SpriteBatch sb, GameTime gameTime, Point playerPos)
//        {
//            switch (CurrentState)
//            {
//                case GasState.Walk:
//                    if (playerPos.X <= Hitbox.Center.X)
//                    {
//                        Move.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.FlipHorizontally);
//                    }
//                    else
//                    {
//                        Move.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.None);
//                    }
//                    return false;
                   

//                case GasState.Shoot:
//                    if (playerPos.X <= Hitbox.Center.X)
//                    {
//                        Shooting.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.FlipHorizontally);
//                    }
//                    else
//                    {
//                        Shooting.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.None);
//                    }
//                    return false;
                    

//                case GasState.Death:
//                    return Death.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.PeachPuff, SpriteEffects.None);
//            }
//            return false;
//        }


//        /// <summary>
//        /// Shoots a bullet at the player's position
//        /// </summary>
//        /// <param name="playerPos">player's position</param>
//        public override void Shoot(Point playerPos)
//        {
//            Vector2 vect = (playerPos - Hitbox.Center).ToVector2() / Vector2.Distance(playerPos.ToVector2(), Hitbox.Center.ToVector2());
//            EnemyBullets.Add(new Projectile(new Rectangle(Hitbox.X + (Hitbox.Width / 2) - (activeBullet.Width / 2), Hitbox.Y + (Hitbox.Height / 2) - (activeBullet.Height / 2),
//                activeBullet.Width, activeBullet.Height), activeBullet, notActiveBullet.Clone(), vect * 10.0f));
//        }

//        /// <summary>
//        /// Moves the enemy away from the player
//        /// </summary>
//        /// <param name="playerPos">current position of the player</param>
//        public override void Walk(Point playerPos)
//        {
//            float distance = Vector2.Distance(playerPos.ToVector2(), Hitbox.Center.ToVector2());

//            //prevents "telepotration"
//            if (distance == 0)
//            {
//                distance = 1;
//            }

//            velocity = (playerPos - Hitbox.Center).ToVector2() / distance * 4;

//            hitboxTemp.X -= (int)velocity.X;
//            hitboxTemp.Y -= (int)velocity.Y;

//            hitboxTemp = WorldManager.Instance.CurrentMap.ResolveCollisions(hitboxTemp);
//            Hitbox = hitboxTemp;
//        }
//    }
//}
