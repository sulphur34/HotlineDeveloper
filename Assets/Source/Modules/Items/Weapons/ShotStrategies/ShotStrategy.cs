using UnityEngine;

namespace Modules.Items.Weapons
{
    internal abstract class ShotStrategy : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        private WeaponConfig _config;

        protected float BulletSpeed => _config.BulletSpeed;

        internal abstract void Shot();

        internal void Init(WeaponConfig config)
        {
            _config = config;
        }

        protected Bullet InstantiateBullet()
        {
            Bullet bullet = Instantiate(_config.BulletPrefab);
            bullet.SetPosition(_bulletSpawnPoint.position);
            return bullet;
        }
    }
}