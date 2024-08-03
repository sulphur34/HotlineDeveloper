using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.CharacterSystem;
using Modules.DamageSystem;
using Modules.EnemySpawnSystem;
using UnityEngine;
using VContainer;

namespace Modules.LevelsSystem
{
    public class EnemyTracker : MonoBehaviour
    {
        [SerializeField] private float _trackerUpdateDelay = 1f;
        
        private Transform _transform;
        private List<Transform> _enemies;
        private Transform _nearestEnemy;
        private CancellationToken _cancellationToken;

        public event Action Activated;
        public event Action AllEnemiesDied;
        public event Action EnemyDied;

        public Vector3 NearestPosition => _nearestEnemy == null ? Vector3.zero : _nearestEnemy.position;


        [Inject]
        public void Construct(EnemySpawner enemySpawner, Player player)
        {
            _cancellationToken = this.GetCancellationTokenOnDestroy();
            _transform = player.transform;
            _enemies = new List<Transform>();
            enemySpawner.Spawned += Add;
        }
        
        public void Activate()
        {
            TrackingNearest(_cancellationToken);
            Activated?.Invoke();
        }

        public Vector3 GetNearestPosition()
        {
            return _nearestEnemy.position;
        }

        private void Add(GameObject character)
        {
            _enemies.Add(character.transform);
            character.GetComponent<DamageReceiverView>().Died += Remove;
        }

        private void Remove(GameObject character)
        {
            _enemies.Remove(character.transform);
            character.GetComponent<DamageReceiverView>().Died -= Remove;
            EnemyDied?.Invoke();
            
            if(_enemies.Count == 0)
                AllEnemiesDied?.Invoke();
        }
        
        private Transform GetNearestCharacter()
        {
            return _enemies
                .OrderBy(enemy => Vector3.Distance(enemy.position, _transform.position))
                .FirstOrDefault();
        }
        
        private async UniTask TrackingNearest(CancellationToken cancellationToken)
        {
            while (enabled)
            {
                _nearestEnemy = GetNearestCharacter();
                await UniTask.Delay(TimeSpan.FromSeconds(_trackerUpdateDelay), cancellationToken: cancellationToken);
            }
        }
    }
}