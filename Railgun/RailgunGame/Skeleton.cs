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
    // 04/12/2023
    //
    // The Skeleton Enemy, hopefully not my magnum opus since "Player" is sorta a big deal. It moves towards the player. 
    // That's really it. In a mostly straight line, too. It's not very bright. I'm hoping this enemy is a pushover, the main
    // reason I want it in the game is so that it can take bullets like a shield and distract players from dodging the
    // enemy bullets.
    internal class Skeleton : Enemy
    {
        private Vector2 velocity;
        private Rectangle hitboxTemp;

        /// <summary>
        /// The constructor for a Skeleton.
        /// </summary>
        /// <param name="move"> The animation a Skeleton undergoes while walking. </param>
        /// <param name="idle"> This is null. Skeletons should never be idle. They will always walk towards the player. </param>
        /// <param name="death"> This is the death animation for a Skeleton. </param>
        /// <param name="hitbox"> The rectangle you should be aiming your gun at. </param>
        public Skeleton(Animation move, Animation death, Rectangle hitbox) : base(move, death, hitbox)
        {
            Health = 50;
            hitboxTemp = Hitbox;
        }

        /// <summary>
        /// Creates a new skeleton with the default animations
        /// </summary>
        /// <param name="hitbox">The hitbox of the enemy</param>
        public Skeleton(Rectangle hitbox)
            : this(AnimationManager.Instance.SkeletonMove.Clone(),
                  AnimationManager.Instance.SkeletonDeath, hitbox) { }

        /// <summary>
        /// This is called every frame for a Skeleton. It enables them to move.
        /// </summary>
        /// <param name="playerPos"> The position of the player. </param>
        public override void Update(Point playerPos)
        {
            if(Health > 0)
            {
                Walk(playerPos);
            }
        }

        /// <summary>
        /// This is what moves the Skeleton. He moves at the breakneck speed of four.
        /// </summary>
        /// <param name="playerPos"> The direction that the Skeleton is moving in. </param>
        public override void Walk(Point playerPos)
        {
            float distance = Vector2.Distance(playerPos.ToVector2(), Hitbox.Center.ToVector2());

            if(distance == 0)
            {
                distance = 1;
            }

            velocity = (playerPos - Hitbox.Center).ToVector2() / distance * 4;

            hitboxTemp.X += (int)velocity.X;
            hitboxTemp.Y += (int)velocity.Y;

            hitboxTemp = WorldManager.Instance.CurrentMap.ResolveCollisions(hitboxTemp);

            Hitbox = hitboxTemp;

            DebugLog.Instance.LogFrame($"X: {Hitbox.X}  Y: {Hitbox.Y}");
        }

        /// <summary>
        /// Draws the skeleton to the screen based 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="gameTime"></param>
        /// <param name="playerPos"></param>
        /// <returns></returns>
        public override bool Draw(SpriteBatch sb, GameTime gameTime, Point playerPos)
        {
            if(Health <= 0)
            {
                return Death.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.PeachPuff, SpriteEffects.None);
            }
            else
            {
                if(playerPos.X <= Hitbox.Center.X)
                {
                    Move.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.FlipHorizontally);
                }
                else
                {
                    Move.Draw(sb, gameTime, Hitbox.Location.ToVector2(), Color.White, SpriteEffects.None);
                }
                return false;
            }
        }
    }
}