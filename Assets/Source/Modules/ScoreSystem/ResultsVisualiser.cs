using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.ScoreSystem
{
    internal class ResultsVisualiser : MonoBehaviour
    {
        [SerializeField] private UINumberAnimator[] _uiNumberAnimators;
        [SerializeField] private float _delay;

        private CancellationTokenSource _cancellationTokenSource;

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }
        
        public void Activate(List<float> results)
        {
            if (results.Count != _uiNumberAnimators.Length)
                throw new ArgumentOutOfRangeException();

            _cancellationTokenSource = new CancellationTokenSource();
            Counting(results);
        }

        private async UniTask Counting(List<float> results)
        {
            for (int i = 0; i < _uiNumberAnimators.Length; i++)
            {
                await _uiNumberAnimators[i].Activate(results[i]);
                await UniTask.WaitForSeconds(_delay, false, PlayerLoopTiming.Update,
                    _cancellationTokenSource.Token);
            }
        }
    }
}