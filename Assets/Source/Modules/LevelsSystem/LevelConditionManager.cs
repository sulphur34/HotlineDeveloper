using System;
using System;
using Modules.CharacterSystem.Player;
using Modules.DamageSystem;
using Modules.FadeSystem;
using Modules.SceneLoaderSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Modules.LevelsSystem
{
    public class LevelConditionManager : MonoBehaviour
    {
        private Level _level;
        private Player _player;
        private EnemyTracker _enemyTracker;
        private EndLevelTrigger _endLevelTrigger;
        private LevelsData _levels;

        public event Action Won;
        public event Action Lost;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
                OnWin();
        }

        private void OnDestroy()
        {
            _player.GetComponent<DamageReceiverView>().Died -= OnLoose;
            _enemyTracker.AllEnemiesDied -= OnWin;
        }

        [Inject]
        private void Construct(
            LevelsData levels,
            Player player,
            EndLevelTrigger endLevelTrigger)
        {
            _levels = levels;
            int levelForCompleteIndex = _levels.ForLoad - 1;
            _level = _levels.Value[levelForCompleteIndex];
            _player = player;
            _endLevelTrigger = endLevelTrigger;
            _player.GetComponent<DamageReceiverView>().Died += OnLoose;
            _endLevelTrigger.Reached += OnWin;
        }

        private void OnWin()
        {
            _level.Complete();
            Won?.Invoke();
        }

        private void OnLoose(GameObject player)
        {
            Lost?.Invoke();
        }
    }
}