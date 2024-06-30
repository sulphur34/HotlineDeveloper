using Modules.BulletPoolSystem;
using Modules.BulletSystem;
using Modules.Weapons.Range;
using UnityEngine;

namespace Modules.Weapons
{
    internal abstract class ShotStrategy : MonoBehaviour
    {
        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;
        
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

        protected float GetRandomShotAngle()
        {
            return Random.Range(_minAngle, _maxAngle);
        }
    }
}