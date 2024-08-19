using Modules.BulletSystem;
using Modules.Weapons.Range;
using UnityEngine;

namespace Modules.Weapons
{
    public abstract class ShotStrategy : MonoBehaviour
    {
        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;

        private RangeWeaponConfig _config;
        private BulletPool _bulletPool;

        private float BulletSpeed => _config.BulletSpeed;

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

        private Bullet InstantiateBullet()
        {
            Bullet bullet = _bulletPool.Get();
            bullet.SetPosition(_bulletSpawnPoint.transform.position);
            return bullet;
        }

        protected void FireBullet()
        {
            Bullet bullet = InstantiateBullet();
            bullet.Init(GetRandomDirection(), BulletSpeed);
        }

        private Vector3 GetRandomDirection()
        {
            float angleInDeg = Random.Range(_minAngle, _maxAngle);
            Quaternion rotation = Quaternion.AngleAxis(angleInDeg, Vector3.up);
            return rotation * transform.forward;
        }
    }
}