using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using Modules.Characters.Enemies.EnemyBehavior.Variables;
using Modules.PlayerWeaponsHandler;
using Source.Modules.InputSystem;
using UnityEngine;
using VContainer;

namespace Modules.Characters.Enemies.EnemyBehavior
{
    [RequireComponent(typeof(EnemyWeaponHandler), typeof(BehaviorManager.BehaviorTree))]
    public class BehaviorSetup : MonoBehaviour
    {
        private BehaviorTree _behaviorTree;
        private BehaviorConfig _behaviorConfig;
        private WeaponTracker _weaponTracker;
        private EnemyWeaponHandler _enemyWeaponHandler;
        private Player _player;
        private AiInput _aiInput;

        [Inject]
        public void Construct(BehaviorConfig behaviorConfig, WeaponTracker weaponTracker, Player player)
        {
            _aiInput = new AiInput();
            _enemyWeaponHandler = GetComponent<EnemyWeaponHandler>();
            _enemyWeaponHandler.Initialize(_aiInput);
            _behaviorTree = GetComponent<BehaviorTree>();
            _behaviorConfig = behaviorConfig;
            _weaponTracker = weaponTracker;
            _player = player;
            SetBehaviour();
        }

        private void SetBehaviour()
        {
            _behaviorTree.ExternalBehavior = _behaviorConfig.BehaviourTree;
            SetVariable(_behaviorConfig.PatrolPoints);
            SetVariable(_behaviorConfig.ActionsMaxDelay);
            SetVariable(_behaviorConfig.ActionsMinDelay);
            SetVariable(_behaviorConfig.VisualDistance);
            SetVariable(_behaviorConfig.FieldOfViewAngle);
            SetVariable(_behaviorConfig.HearingDistance);
            SetVariable(new KeyValuePair<string,AiInput>("AiInput", _aiInput));
            SetGlobalVariable(new KeyValuePair<string,WeaponTracker>("WeaponTracker", _weaponTracker), new SharedWeaponTracker());
            SetGlobalVariable(new KeyValuePair<string,GameObject>("Target", _player.gameObject), new SharedGameObject());
        }

        private void SetVariable<T>(KeyValuePair<string, T> variableData)
        {
            var variable = _behaviorTree.GetVariable(variableData.Key);
            variable.SetValue(variableData.Value);
        }

        private void SetGlobalVariable<T, T1>(KeyValuePair<string, T> variableData, T1 sharedVariable) where T1 : SharedVariable<T>
        {
            sharedVariable.Value = variableData.Value;
            GlobalVariables.Instance.SetVariable(variableData.Key, sharedVariable);
        }
    }
}