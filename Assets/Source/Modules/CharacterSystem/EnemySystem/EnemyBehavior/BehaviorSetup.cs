using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using Modules.Characters.Enemies.EnemyBehavior.Variables;
using Modules.CharacterSystem.Player;
using Modules.DamageSystem;
using Modules.PlayerWeaponsHandler;
using Modules.InputSystem;
using Modules.CharacterSystem.Enemies.EnemyBehavior.Variables;
using Modules.EnemySpawnSystem;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior
{
    [RequireComponent(typeof(EnemyWeaponHandler), typeof(BehaviorManager.BehaviorTree))]
    public class BehaviorSetup : MonoBehaviour
    {
        public const string AiInputName = "AiInput";
        public const string WeaponTrackerName = "WeaponTracker";
        public const string TargetName = "Target";
        public const string DamageReceiverName = "DamageReceiver";
        public const string PlayerWeaponHandlerName = "PlayerWeaponHandler";

        private BehaviorTree _behaviorTree;
        private BehaviorConfig _behaviorConfig;
        private WeaponTracker _weaponTracker;
        private PlayerWeaponHandler _playerWeaponHandler;
        private EnemyWeaponHandler _enemyWeaponHandler;
        private Player _player;
        private AiInput _aiInput;
        private DamageReceiverView _damageReceiver;
        private PatrolRoute _patrolRoute;

        public void Initialize(BehaviorConfig behaviorConfig, PatrolRoute patrolRoute, WeaponTracker weaponTracker,
            Player player)
        {
            _aiInput = new AiInput();
            _enemyWeaponHandler = GetComponent<EnemyWeaponHandler>();
            _damageReceiver = GetComponent<DamageReceiverView>();
            _enemyWeaponHandler.Initialize(_aiInput);
            _behaviorTree = GetComponent<BehaviorTree>();
            _behaviorConfig = behaviorConfig;
            _weaponTracker = weaponTracker;
            _player = player;
            _playerWeaponHandler = _player.GetComponent<PlayerWeaponHandler>();
            _patrolRoute = patrolRoute;
            SetBehaviour();
        }

        private void SetBehaviour()
        {
            _behaviorTree.ExternalBehavior = _behaviorConfig.BehaviourTree;

            foreach (KeyValuePair<string, float> parameter in _behaviorConfig.GetParameters())
                SetVariable(parameter);

            SetVariable(_patrolRoute.GetRoute());
            SetVariable(new KeyValuePair<string, AiInput>(AiInputName, _aiInput));
            SetVariable(new KeyValuePair<string, DamageReceiverView>(DamageReceiverName, _damageReceiver));
            SetGlobalVariable(
                new KeyValuePair<string, WeaponTracker>(WeaponTrackerName, _weaponTracker),
                new SharedWeaponTracker());
            SetGlobalVariable(
                new KeyValuePair<string, GameObject>(TargetName, _player.gameObject),
                new SharedGameObject());
            SetGlobalVariable(
                new KeyValuePair<string, PlayerWeaponHandler>(PlayerWeaponHandlerName, _playerWeaponHandler),
                new SharedPlayerWeaponHandler());
        }

        private void SetVariable<T>(KeyValuePair<string, T> variableData)
        {
            var variable = _behaviorTree.GetVariable(variableData.Key);
            variable.SetValue(variableData.Value);
        }

        private void SetGlobalVariable<T, T1>(KeyValuePair<string, T> variableData, T1 sharedVariable)
            where T1 : SharedVariable<T>
        {
            sharedVariable.Value = variableData.Value;
            GlobalVariables.Instance.SetVariable(variableData.Key, sharedVariable);
        }
    }
}