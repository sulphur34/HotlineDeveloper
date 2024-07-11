using System;
using UnityEngine;
using VContainer;

namespace Modules.LevelsSystem
{
    public class LevelHandler : MonoBehaviour
    {
        private Level _level;

        public event Action LevelCompleted;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _level.Complete();
                LevelCompleted?.Invoke();
            }
        }

        [Inject]
        private void Constructe(LevelsData levels)
        {
            int levelForCompleteIndex = levels.ForLoad - 1;
            _level = levels.Value[levelForCompleteIndex];
        }
    }
}
