using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.CharacterSystem.Player;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Modules.LevelsSystem
{
    [RequireComponent(typeof(Image))]
    public class UIDirectionPointer : MonoBehaviour
    {
        private EnemyTracker _enemyTracker;
        private Camera _camera;
        private RectTransform _imageTransform;
        private Transform _playerTransform;
        private CancellationTokenSource _cancellationTokenSource;

        private void Start()
        {
            RotatingTowardsTarget().Forget();
        }

        private void OnDestroy()
        {
            StopRotation();
        }

        [Inject]
        public void Construct(EnemyTracker enemyTracker, Player player)
        {
            _imageTransform = GetComponent<RectTransform>();
            _enemyTracker = enemyTracker;
            _camera = Camera.main;
            _playerTransform = player.transform;
            _cancellationTokenSource = new CancellationTokenSource();
            _enemyTracker.AllEnemiesDied += StopRotation;
        }

        private async UniTask RotatingTowardsTarget()
        {
            while (enabled)
            {
                Vector3 referenceScreenPosition = _camera.WorldToScreenPoint(_playerTransform.position);
                Vector3 targetScreenPosition = _camera.WorldToScreenPoint(_enemyTracker.NearestEnemyPosition);
                Vector3 direction = targetScreenPosition - referenceScreenPosition;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, 0, angle + 90f);
                _imageTransform.rotation = targetRotation;
                await UniTask.Yield(_cancellationTokenSource.Token);
            }
        }

        private void StopRotation()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}