using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.LevelsSystem;
using UnityEngine;
using VContainer;

namespace Modules.ScoreSystem
{
    public class ScoreCounter
    {
        private readonly float _multiplierDelay = 2f;
        private readonly uint _defaultMultiplier = 1;
        private readonly float _killScore = 100f;

        private Stack<ScoreData> _scores;
        private float _timePassed;
        private CancellationTokenSource _cancellationTokenSource;
        private EnemyTracker _enemyTracker;
        private uint _currentScore;

        [Inject]
        public ScoreCounter(EnemyTracker enemyTracker)
        {
            _enemyTracker = enemyTracker;
            _enemyTracker.Activated += Activate;
        }

        public event Action<uint> KillScoreChanged;
        public event Action<uint> TimeScoreChanged;

        public uint TotalScore { get; private set; }

        private float _timeMultiplier => 5.7497f - 0.9674f * Mathf.Log(_timePassed);

        private void Activate()
        {
            _currentScore = 0;
            _scores = new Stack<ScoreData>();
            _enemyTracker.EnemyDied += OnEnemyKill;
            _enemyTracker.AllEnemiesDied += OnAllEnemiesDie;
            _cancellationTokenSource = new CancellationTokenSource();
            Counting();
        }

        private void Deactivate()
        {
            _cancellationTokenSource.Cancel();
            _enemyTracker.EnemyDied += OnEnemyKill;
        }

        private async UniTask Counting()
        {
            _timePassed += Time.deltaTime;
            await UniTask.Yield(_cancellationTokenSource.Token);
        }
        
        private void OnAllEnemiesDie()
        {
            Deactivate();
            TimeScoreChanged?.Invoke(GetTimeScore());
            UpdateTotalScore();
        }

        private uint GetTimeScore()
        {
            return Convert.ToUInt32(_timeMultiplier * _scores.Count * _killScore);
        }

        private void OnEnemyKill()
        {
            uint multiplier = _defaultMultiplier;
            
            if (_scores.Count > 0)
            {
                var lastScoreData = _scores.Peek();
                multiplier = Time.timeSinceLevelLoad - lastScoreData.Time < _multiplierDelay
                    ? lastScoreData.Multiplier + 1
                    : _defaultMultiplier;
            }

            _scores.Push(new ScoreData(Time.timeSinceLevelLoad, multiplier));
            AddScore(_killScore * multiplier);
        }

        private void AddScore(float value)
        {
            _currentScore += Convert.ToUInt32(value);
            KillScoreChanged?.Invoke(_currentScore);
            UpdateTotalScore();
        }

        private void UpdateTotalScore()
        {
            TotalScore = _currentScore + GetTimeScore();
        }
    }
}