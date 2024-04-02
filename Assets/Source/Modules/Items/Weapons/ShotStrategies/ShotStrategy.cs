using Modules.BulletPoolSystem;
using Modules.BulletSystem;
using Modules.Items.Weapons.Range;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal abstract class ShotStrategy : MonoBehaviour
    {
        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;
        
        private RangeWeaponConfig _config;
        private BulletPool _bulletPool;

        protected float BulletSpeed => _config.BulletSpeed;

        private void OnValidate()
        {
            if (_bulletSpawnPoint == null)
                _bulletSpawnPoint = GetComponentInChildren<BulletSpawnPoint>(true);
        }

        internal abstract void Shot();

        internal void Init(RangeWeaponConfig config, BulletPool bulletPool)
        {
            _config = config;
            _bulletPool = bulletPool;
        }

        protected Bullet InstantiateBullet()
        {
            Bullet bullet = _bulletPool.Get();
            bullet.SetPosition(_bulletSpawnPoint.transform.position);
            return bullet;
        }
    }
}