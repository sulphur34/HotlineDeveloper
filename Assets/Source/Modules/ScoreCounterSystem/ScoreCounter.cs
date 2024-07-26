using System;
using UnityEngine;
using VContainer;

namespace Modules.ScoreCounterSystem
{
  /*  [Serializable]
    public class ScoreCounter 
    {
        public event Action Changed;

        public ScoreCounter(int score)
        {
            Score = score;
        }

        [field: SerializeField] public int Score { get; private set; }

        public void Add(int count)
        {
            if (count < 0)
                throw new ArgumentException();

            Score += count;
            Changed?.Invoke();
        }
    }

    public class ScoreAdder : MonoBehaviour
    {
        private ScoreCounter _scoreCounter;

        public event Action Added;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _scoreCounter.Add(10);
                Added?.Invoke();
            }
        }

        [Inject]
        public void Init(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }
    }*/
}