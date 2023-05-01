using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Util
{
    internal static class SoundManager
    {
        public static Song MainTheme { get; set; }
        public static Song PauseTheme { get; set; }
        public static Song GameTheme { get; set; }
        public static Song GameOverTheme { get; set; }

        public static SoundEffect SfxBulletExplosion { get; set; }
        public static SoundEffect SfxDash { get; set; }
        public static SoundEffect SfxEnemyDie { get; set; }
        public static SoundEffect SfxEnemyHurt { get; set; }
        public static SoundEffect SfxHeal { get; set; }
        public static SoundEffect SfxMenuBack { get; set; }
        public static SoundEffect SfxMenuSelect { get; set; }
        public static SoundEffect SfxOutOfAmmo { get; set; }
        public static SoundEffect SfxPlayerHurt { get; set; }
        public static SoundEffect SfxPlayerWalk { get; set; }
        public static SoundEffect SfxReload { get; set; }
        public static SoundEffect SfxShoot { get; set; }



        //mainTheme = Content.Load<Song>("Tension Rail");
        //pauseTheme = Content.Load<Song>("Endless Express");
        //gameTheme = Content.Load<Song>("battlemusic");
        //gameOverTheme = Content.Load<Song>("gameover");

        //sfxBulletExplosion = Content.Load<SoundEffect>("SFX/Bullet Explosion");
        //sfxDash = Content.Load<SoundEffect>("SFX/Dash");
        //sfxEnemyDie = Content.Load<SoundEffect>("SFX/Enemy Die");
        //sfxEnemyHurt = Content.Load<SoundEffect>("SFX/Enemy Hurt");
        //sfxHeal = Content.Load<SoundEffect>("SFX/Heal");
        //sfxMenuBack = Content.Load<SoundEffect>("SFX/Menu Back");
        //sfxMenuSelect = Content.Load<SoundEffect>("SFX/Menu Select");
        //sfxOutOfAmmo = Content.Load<SoundEffect>("SFX/Out of Ammo");
        //sfxPlayerHurt = Content.Load<SoundEffect>("SFX/Player Hurt");
        //sfxPlayerWalk = Content.Load<SoundEffect>("SFX/Player Walk");
        //sfxReload = Content.Load<SoundEffect>("SFX/Reload");
        //sfxShoot = Content.Load<SoundEffect>("SFX/Shoot");

    }
}
