using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Util
{
    internal class EnemyProjManager
    {
        /// <summary>
        /// creates a new projectile manager
        /// </summary>
        private EnemyProjManager()
        {
            Projectiles= new List<Projectile>();
        }

        /// <summary>
        /// the singleton instance of projectile manager
        /// </summary>
        public static EnemyProjManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyProjManager();
                }
                return instance;
            }

        }

        private static EnemyProjManager instance;

        /// <summary>
        /// enemy projectiles to be kept track of
        /// </summary>
        public List<Projectile> Projectiles { get; set; }

        /// <summary>
        /// updates the position of each projectile in the manager
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public void Update(GameTime gameTime)
        {
            foreach (Projectile projectile in Projectiles)
            {
                projectile.Update(gameTime);
            }
        }

        /// <summary>
        /// draws all projectiles and removes them if they
        /// reached the last frame of their animation
        /// </summary>
        /// <param name="sb">_spritebatch</param>
        /// <param name="gameTime">gameTime</param>
        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            for (int i = 0; i < Projectiles.Count; i++)
            {
                if (Projectiles[i].Draw(sb, gameTime))
                {
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
