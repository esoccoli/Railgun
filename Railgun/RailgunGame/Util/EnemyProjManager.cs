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
    }
}
