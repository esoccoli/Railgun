//I commented this out since there were errors -Jonathan

//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Railgun.RailgunGame.Util;

////Nathan McAndrew
////Enemy that walks away from the player
//namespace Railgun.RailgunGame
//{
//    internal class GasMan : Enemy
//    {
//        private enum GasState
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

//        public List<Projectile> EnemyBullets { get; set; }

//        /// <summary>
//        /// animation to play when the enemy fires projectiles at the player
//        /// </summary>
//        public Animation Shooting { get; set; }

//        /// <summary>
//        /// creates an instance of an enemy that shoots at the player and runs away
//        /// </summary>
//        /// <param name="move"></param>
//        /// <param name="death"></param>
//        /// <param name="hitbox"></param>
//        /// <param name="shoot"></param>
//        public GasMan(Animation move, Animation death, Rectangle hitbox, Animation shoot) : base(move, death, hitbox)
//        {
//            Health = 40;
//            hitboxTemp = Hitbox;
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
//    }
//}
