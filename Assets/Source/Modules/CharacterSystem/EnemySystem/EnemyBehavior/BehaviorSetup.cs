using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using Modules.Characters.Enemies.EnemyBehavior.Variables;
using Modules.CharacterSystem;
using Modules.DamageReceiverSystem;
using Modules.WeaponsHandler;
using Modules.InputSystem;
using Modules.CharacterSystem.Enemies.EnemyBehavior.Variables;
using Modules.EnemySpawnSystem;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using Modules.Weapons.WeaponItemSystem;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior
{
    [RequireComponent(
        typeof(EnemyWeaponHandlerSetup),
        typeof(WeaponHandlerView),
        typeof(BehaviorManager.BehaviorTree))]
    internal class BehaviorSetup : MonoBehaviour
    {
        private const string AiInputName = "AiInput";
        private const string WeaponTrackerName = "WeaponTracker";
        private const string TargetName = "Target";
        private const string DamageReceiverName = "DamageReceiver";
        private const string PlayerWeaponHandlerName = "PlayerWeaponHandler";

        private BehaviorTree _behaviorTree;
        private BehaviorConfig _behaviorConfig;
        private WeaponTracker _weaponTracker;
        private WeaponHandlerView _playerWeaponHandlerView;
        private EnemyWeaponHandlerSetup _weaponHandlerSetup;
        private Player _player;
        private AiInput _aiInput;
        private DamageReceiverView _damageReceiver;
        private PatrolRoute _patrolRoute;

        internal void Initialize(BehaviorConfig behaviorConfig, PatrolRoute patrolRoute, WeaponTracker weaponTracker,
            Player player, WeaponItemInitializer weaponItemInitializer)
        {
            _aiInput = new AiInput();
            _weaponHandlerSetup = GetComponent<EnemyWeaponHandlerSetup>();
            _damageReceiver = GetComponent<DamageReceiverView>();
            _weaponHandlerSetup.Initialize(_aiInput, weaponItemInitializer);
            _behaviorTree = GetComponent<BehaviorTree>();
            _behaviorConfig = behaviorConfig;
            _weaponTracker = weaponTracker;
            _player = player;
            _playerWeaponHandlerView = _player.GetComponent<WeaponHandlerView>();
            _patrolRoute = patrolRoute;
            SetBehaviour();
        }

        private void SetBehaviour()
        {
            SetGlobalVariables();
            _behaviorTree.ExternalBehavior = _behaviorConfig.BehaviourTree;
            SeVariables();
        }

        private void SeVariables()
        {
            foreach (KeyValuePair<string, float> parameter in _behaviorConfig.GetParameters())
                SetVariable(parameter);

            SetVariable(_patrolRoute.GetRoute());
            SetVariable(new KeyValuePair<string, AiInput>(AiInputName, _aiInput));
            SetVariable(new KeyValuePair<string, DamageReceiverView>(DamageReceiverName, _damageReceiver));
        }

        private void SetGlobalVariables()
        {
            SetGlobalVariable(
                new KeyValuePair<string, WeaponTracker>(WeaponTrackerName, _weaponTracker),
                new SharedWeaponTracker());
            SetGlobalVariable(
                new KeyValuePair<string, GameObject>(TargetName, _player.gameObject),
                new SharedGameObject());
            SetGlobalVariable(
                new KeyValuePair<string, WeaponHandlerView>(PlayerWeaponHandlerName, _playerWeaponHandlerView),
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