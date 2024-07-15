using Modules.LevelsSystem;
using UnityEngine;
using VContainer;

namespace Modules.ScoreSystem
{
    public class ScoreCounterView : MonoBehaviour
    {
        [SerializeField] private ScoreLabel _scoreLabel;
        
        private ScoreCounter _scoreCounter;
        
        [Inject]
        public void Construct(EnemyTracker enemyTracker)
        {
            _scoreCounter = new ScoreCounter(enemyTracker);
            _scoreCounter.KillScoreChanged += OnKillScoreChange;
            _scoreLabel.Initialize();
        }

        private void OnKillScoreChange(uint value)
        {
            _scoreLabel.SetValue(value);
        }
    }
}