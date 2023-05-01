using Microsoft.Xna.Framework.Graphics;

namespace Railgun.RailgunGame.Util
{
    /// <summary>
    /// A singleton manager that contains animations and textures
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/21/2023
    /// </summary>
    internal class VisualManager
    {
        #region Singleton Design

        /// <summary>
        /// Creates a new animation manager
        /// </summary>
        private VisualManager()
        {

        }

        /// <summary>
        /// The singleton instance of this animation manager
        /// </summary>
        public static VisualManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VisualManager();
                }
                return instance;
            }
        }
        private static VisualManager instance;

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

        /// <summary>
        /// gas man's move animation
        /// </summary>
        public Animation GasManMove { get; set; }

        /// <summary>
        /// Gas man's death animation
        /// </summary>
        public Animation GasManDeath { get; set; }

        /// <summary>
        /// gas man's shoot animation
        /// </summary>
        public Animation GasManShoot { get; set; }

        #endregion

        #region Textures

        /// <summary>
        /// The texture for a door
        /// </summary>
        public Texture2D DoorTexture { get; set; }

        /// <summary>
        /// texture for active bullets
        /// </summary>
        public Texture2D BulletTexture { get; set; }
        
        #endregion

    }
}
