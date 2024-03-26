using Modules.BulletSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Modules.BulletPoolSystem
{
    public class BulletPool : IDisposable
    {
        private readonly Bullet _prefab;
        private readonly Transform _container;
        private readonly ObjectPool<Bullet> _pool;

        private readonly List<Bullet> _bullets = new List<Bullet>();

        public BulletPool(Bullet prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
            _pool = new ObjectPool<Bullet>(OnCreate, OnGet, OnRelease, OnDestroy);
        }

        public Bullet Get()
        {
            Bullet bullet = _pool.Get();
            bullet.SetInterpolation(RigidbodyInterpolation.Interpolate);
            return bullet;
        }

        public void Dispose()
        {
            foreach (Bullet bullet in _bullets)
                bullet.LifespanEnded -= OnLifespanEnded;
        }

        private Bullet OnCreate()
        {
            Bullet bullet = Object.Instantiate(_prefab, _container);
            _bullets.Add(bullet);
            bullet.LifespanEnded += OnLifespanEnded;
            return bullet;
        }

        private void OnGet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private void OnRelease(Bullet bullet)
        {
            bullet.SetInterpolation(RigidbodyInterpolation.None);
            bullet.gameObject.SetActive(false);
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