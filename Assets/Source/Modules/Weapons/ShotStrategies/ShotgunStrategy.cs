using Modules.BulletSystem;
using UnityEngine;

namespace Modules.Weapons
{
    internal class ShotgunStrategy : ShotStrategy
    {
        [SerializeField] private uint _bulletsNumber;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;

        internal override void Shot()
        {
            for (int i = 0; i < _bulletsNumber; i++)
            {
                float t = (float)i / (_bulletsNumber - 1);
                float angleInDeg = Mathf.Lerp(_minAngle, _maxAngle, t);
                Quaternion rotation = Quaternion.AngleAxis(angleInDeg, Vector3.up);
                Vector3 direction = rotation * transform.forward;

                Bullet bullet = InstantiateBullet();
                bullet.Init(direction, BulletSpeed);
            }
        }
    }
}