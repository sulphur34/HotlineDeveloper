using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.CharacterSystem;
using Modules.LevelsSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Modules.GUISystem
{
    [RequireComponent(typeof(Image))]
    public class UIDirectionPointer : MonoBehaviour
    {
        private EnemyTracker _enemyTracker;
        private Camera _camera;
        private RectTransform _imageTransform;
        private Transform _playerTransform;
        private CancellationTokenSource _cancellationTokenSource;
        private Vector3 _endLevelTriggerPosition;

        private void Start()
        {
            RotatingTowardsTarget(_enemyTracker.GetNearestPosition).Forget();
        }

        private void OnDestroy()
        {
            StopRotation();
        }

        [Inject]
        public void Construct(EnemyTracker enemyTracker, Player player, EndLevelTrigger endLevelTrigger)
        {
            _imageTransform = GetComponent<RectTransform>();
            _enemyTracker = enemyTracker;
            _camera = Camera.main;
            _playerTransform = player.transform;
            _cancellationTokenSource = new CancellationTokenSource();
            _endLevelTriggerPosition = endLevelTrigger.transform.position;
            _enemyTracker.AllEnemiesDied += OnAllEnemyKilled;
        }

        private async UniTask RotatingTowardsTarget(Func<Vector3> targetPosition)
        {
            while (enabled)
            {
                Vector3 referenceScreenPosition = _camera.WorldToScreenPoint(_playerTransform.position);
                Vector3 targetScreenPosition = _camera.WorldToScreenPoint(targetPosition.Invoke());
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

        private void OnAllEnemyKilled()
        {
            StopRotation();
            _cancellationTokenSource = new CancellationTokenSource();
            RotatingTowardsTarget(() => _endLevelTriggerPosition);
        }
    }
}