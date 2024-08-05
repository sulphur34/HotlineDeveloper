using System;
using System.Collections.Generic;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Modules.BulletSystem
{
    public class BulletPool : IDisposable
    {
        private readonly Bullet _prefab;
        private readonly ObjectPool<Bullet> _pool;

        private readonly List<Bullet> _bullets = new List<Bullet>();

        public BulletPool(Bullet prefab)
        {
            _prefab = prefab;
            _pool = new ObjectPool<Bullet>(OnCreate, OnGet, OnRelease, OnDestroy);
        }

        public Bullet Get()
        {
            Bullet bullet = _pool.Get();
            return bullet;
        }

        public void Dispose()
        {
            foreach (Bullet bullet in _bullets)
                bullet.LifespanEnded -= OnLifespanEnded;
        }

        private Bullet OnCreate()
        {
            Bullet bullet = Object.Instantiate(_prefab);
            _bullets.Add(bullet);
            bullet.LifespanEnded += OnLifespanEnded;
            return bullet;
        }

        private void OnGet(Bullet bullet)
        {
            bullet.Collider.enabled = true;
        }

        private void OnRelease(Bullet bullet)
        {
            bullet.Collider.enabled = false;
        }

        private void OnDestroy(Bullet bullet)
        {
            Object.Destroy(bullet.gameObject);
        }

        private void OnLifespanEnded(Bullet bullet)
        {
            _pool.Release(bullet);
        }
    }
}