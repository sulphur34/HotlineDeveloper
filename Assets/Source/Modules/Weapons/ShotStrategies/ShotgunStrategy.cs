using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Modules.Weapons.ShotStrategies
{
    internal class ShotgunStrategy : ShotStrategy
    {
        private readonly float _minFireDelay = 0f;

        [SerializeField] private uint _bulletsNumber;
        [SerializeField] private float _maxFireDelay = 0.005f;

        private Coroutine _coroutine;

        internal override void Shot()
        {
            StopRoutine();
            _coroutine = StartCoroutine(ShootingRoutine());
        }

        private void OnDisable()
        {
            StopRoutine();
        }

        private IEnumerator ShootingRoutine()
        {
            for (int i = 0; i < _bulletsNumber; i++)
            {
                FireBullet();
                yield return GetRandomFireDelay();
            }
        }

        private void StopRoutine()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private WaitForSeconds GetRandomFireDelay()
        {
            return new WaitForSeconds(Random.Range(_minFireDelay, _maxFireDelay));
        }
    }
}