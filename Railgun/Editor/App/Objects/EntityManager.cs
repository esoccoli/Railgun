using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Objects
{
    /// <summary>
    /// A singleton class that contains useful data and info for entities
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/21/2023
    /// </summary>
    internal class EntityManager
    {
        #region Singleton Design

        /// <summary>
        /// The singleton instance of this entity manager
        /// </summary>
        public static EntityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EntityManager();
                }
                return instance;
            }
        }
        private static EntityManager instance;

        /// <summary>
        /// Creates a new entity manager
        /// </summary>
        private EntityManager() { }

        #endregion

        #region Textures

        /// <summary>
        /// For anything that doesn't have a texture yet
        /// </summary>
        public Texture2D UndefinedTexture { get; set; }

        /// <summary>
        /// The texture for enemy 1
        /// </summary>
        public Texture2D Skeleton { get; set; }

        /// <summary>
        /// The texture for enemy 2
        /// </summary>
        public Texture2D GasMan { get; set; }

        /// <summary>
        /// The texture for enemy 3
        /// </summary>
        public Texture2D Ghost { get; set; }

        /// <summary>
        /// The texture for the enterence marker
        /// </summary>
        public Texture2D Enterence { get; set; }

        /// <summary>
        /// The texture for the exit marker
        /// </summary>
        public Texture2D Exit { get; set; }

        #endregion

        #region Editing

        /// <summary>
        /// The index id to place
        /// </summary>
        public int CurrentEntity { get; set; }

        #endregion
    }
}
