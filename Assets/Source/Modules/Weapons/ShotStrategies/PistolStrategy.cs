using Modules.BulletSystem;

namespace Modules.Weapons
{
    public class PistolStrategy : ShotStrategy
    {
        internal override void Shot()
        {
            FireBullet();
        }
    }
}