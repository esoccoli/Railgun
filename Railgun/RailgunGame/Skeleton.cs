﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railgun.RailgunGame.Util;

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
        private int speed;
        private Vector2 velocity;
        private Rectangle hitboxTemp;

        /// <summary>
        /// The constructor for a Skeleton.
        /// </summary>
        /// <param name="move"> The animation a Skeleton undergoes while walking. </param>
        /// <param name="idle"> This is null. Skeletons should never be idle. They will always walk towards the player. </param>
        /// <param name="death"> This is the death animation for a Skeleton. </param>
        /// <param name="hitbox"> The rectangle you should be aiming your gun at. </param>
        public Skeleton(Animation move, Animation idle, Animation death, Rectangle hitbox) : base(move, idle, death, hitbox)
        {
            speed = 5;
            Health = 25;
            hitboxTemp = Hitbox;
        }

        public override void Walk(Point playerPos)
        {
            velocity = (playerPos - Hitbox.Center).ToVector2() / Vector2.Distance(playerPos.ToVector2(), Hitbox.Center.ToVector2());

            hitboxTemp.X += (int)velocity.X;
            hitboxTemp.Y += (int)velocity.Y;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {

        }
    }
}