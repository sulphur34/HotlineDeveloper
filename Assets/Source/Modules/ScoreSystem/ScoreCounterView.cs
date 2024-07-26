using System.Collections.Generic;
using Modules.LevelsSystem;
using Source.Modules.GUISystem;
using UnityEngine;
using VContainer;

namespace Modules.ScoreSystem
{
    public class ScoreCounterView : MonoBehaviour
    {
        [SerializeField] private ScoreLabel _scoreLabel;
        [SerializeField] private ResultsVisualiser _resultsVisualiser;

        private ScoreCounter _scoreCounter;
        private LevelConditionManager _levelConditionManager;
        private float _killScore;
        private float _timeScore;

        public float TotalScore => _killScore + _timeScore;

        [Inject]
        public void Construct(ScoreCounter scoreCounter, LevelConditionManager levelConditionManager)
        {
            _levelConditionManager = levelConditionManager;
            _scoreCounter = scoreCounter;
            _scoreCounter.KillScoreChanged += OnKillScoreChange;
            _scoreCounter.TimeScoreChanged += OnTimeScoreChange;
            _levelConditionManager.Won += OnWin;
            _scoreLabel.Initialize();
        }

        private void OnWin()
        {
            _resultsVisualiser.Activate(new List<float>() { _killScore, _timeScore, _killScore + _timeScore });
        }

        private void OnKillScoreChange(uint value)
        {
            _scoreLabel.SetValue(value);
            _killScore = value;
        }

        private void OnTimeScoreChange(uint value)
        {
            _timeScore = value;
        }
    }
}