using System;
using Modules.CharacterSystem;
using Modules.DamageReceiverSystem;
using Modules.InputSystem.PlayerInput;
using UnityEngine;
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
        private InputController _inputController;
        private DamageReceiverView _damageReceiver;

        public event Action Won;

        public event Action Lost;

        public int LevelCompleteIndex { get; private set; }

        private void OnDestroy()
        {
            if (_damageReceiver != null)
                _damageReceiver.Died += OnLoose;

            if (_enemyTracker != null)
                _enemyTracker.AllEnemiesDied -= OnWin;
        }

        [Inject]
        private void Construct(
            LevelsData levels,
            Player player,
            EndLevelTrigger endLevelTrigger,
            InputController inputController)
        {
            _levels = levels;
            _inputController = inputController;
            int levelIndexOffset = 1;
            LevelCompleteIndex = _levels.ForLoad - levelIndexOffset;
            _level = _levels.Value[LevelCompleteIndex];
            _player = player;
            _endLevelTrigger = endLevelTrigger;
            _damageReceiver = _player.GetComponent<DamageReceiverView>();
            _damageReceiver.Died += OnLoose;
            _endLevelTrigger.Reached += OnWin;
        }

        private void OnWin()
        {
            Destroy(_inputController);
            _level.Complete();
            Won?.Invoke();
        }

        private void OnLoose(GameObject player)
        {
            Lost?.Invoke();
        }
    }
}