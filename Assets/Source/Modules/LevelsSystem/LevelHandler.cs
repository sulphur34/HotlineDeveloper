using Modules.CharacterSystem.Player;
using Modules.DamageSystem;
using UnityEngine;
using VContainer;

namespace Modules.LevelsSystem
{
    public class LevelHandler : MonoBehaviour
    {
        private Level _level;
        private Player _player;
        private EnemyTracker _enemyTracker;

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
        private void Construct(LevelsData levels, Player player, EnemyTracker enemyTracker)
        {
            int levelForCompleteIndex = levels.ForLoad - 1;
            _level = levels.Value[levelForCompleteIndex];
            _player = player;
            _enemyTracker = enemyTracker;
            _player.GetComponent<DamageReceiverView>().Died += OnLoose;
            _enemyTracker.AllEnemiesDied += OnWin;
        }

        private void OnWin()
        {
            Debug.Log("Level complete by killing all enemies");
            _level.Complete();
        }

        private void OnLoose(GameObject player)
        {
            
        }
    }
}
