using Modules.BulletSystem;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class PistolStrategy : ShotStrategy
    {
        internal override void Shot()
        {
            Bullet bullet = InstantiateBullet();
            bullet.Init(Vector3.forward, BulletSpeed);
        }
    }
}