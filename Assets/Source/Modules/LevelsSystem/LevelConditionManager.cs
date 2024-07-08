﻿using Modules.CharacterSystem.Player;
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
        private Fade _fade;
        private SceneLoader _sceneLoader;

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
            EndLevelTrigger endLevelTrigger,
            Fade fade,
             SceneLoader sceneLoader)
        {
            int levelForCompleteIndex = levels.ForLoad - 1;
            _level = levels.Value[levelForCompleteIndex];
            _player = player;
            _endLevelTrigger = endLevelTrigger;
            _player.GetComponent<DamageReceiverView>().Died += OnLoose;
            _endLevelTrigger.Reached += OnWin;

            _fade = fade;
            _sceneLoader = sceneLoader;
        }

        private void OnWin()
        {
            Debug.Log("Level complete by killing all enemies");
            _level.Complete();
            _fade.In();
            _sceneLoader.Load("Menu", _fade);
        }

        private void OnLoose(GameObject player)
        {
            Debug.Log("Level lost, you are dead");
            _fade.In();
            _sceneLoader.Load(SceneManager.GetActiveScene().name, _fade);
        }
    }
}
