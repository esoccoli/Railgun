﻿using Microsoft.Xna.Framework.Graphics;
using Railgun.RailgunGame.Tilemapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Util
{
    /// <summary>
    /// A singleton manager that contains animations
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/21/2023
    /// </summary>
    internal class AnimationManager
    {
        #region Singleton Design

        /// <summary>
        /// Creates a new animation manager
        /// </summary>
        private AnimationManager()
        {

        }

        /// <summary>
        /// The singleton instance of this animation manager
        /// </summary>
        public static AnimationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnimationManager();
                }
                return instance;
            }
        }
        private static AnimationManager instance;

        #endregion

        #region Animations

        /// <summary>
        /// The idle animation for the player
        /// </summary>
        public Animation PlayerIdle { get; set; }

        /// <summary>
        /// The moving animation for the player
        /// </summary>
        public Animation PlayerMove { get; set; }

        /// <summary>
        /// The death animation for the player
        /// </summary>
        public Animation PlayerDeath { get; set; }

        /// <summary>
        /// The bullet collision animation
        /// </summary>
        public Animation BulletCollide { get; set; }

        /// <summary>
        /// The skeleton moving animation
        /// </summary>
        public Animation SkeletonMove { get; set; }

        /// <summary>
        /// The skeleton death animation
        /// </summary>
        public Animation SkeletonDeath { get; set; }

        #endregion

    }
}
