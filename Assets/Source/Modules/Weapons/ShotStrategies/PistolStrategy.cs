using Modules.BulletSystem;

namespace Modules.Weapons
{
    internal class PistolStrategy : ShotStrategy
    {
        internal override void Shot()
        {
            Bullet bullet = InstantiateBullet();
            bullet.Init(transform.forward, BulletSpeed);
        }
    }
}