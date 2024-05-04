using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using Modules.Characters.Enemies.EnemyBehavior.Variables;
using Modules.DamageSystem;
using Modules.PlayerWeaponsHandler;
using Source.Modules.InputSystem;
using UnityEngine;
using VContainer;

namespace Modules.Characters.Enemies.EnemyBehavior
{
    [RequireComponent(typeof(EnemyWeaponHandler), typeof(BehaviorManager.BehaviorTree))]
    public class BehaviorSetup : MonoBehaviour
    {
        public const string AiInputName = "AiInput";
        public const string WeaponTrackerName = "WeaponTracker";
        public const string TargetName = "Target";
        public const string DamageReceiverName = "DamageReceiver";

        private BehaviorTree _behaviorTree;
        private BehaviorConfig _behaviorConfig;
        private WeaponTracker _weaponTracker;
        private EnemyWeaponHandler _enemyWeaponHandler;
        private Player _player;
        private AiInput _aiInput;
        private DamageReceiverView _damageReceiver;

        [Inject]
        public void Construct(BehaviorConfig behaviorConfig, WeaponTracker weaponTracker, Player player)
        {
            _aiInput = new AiInput();
            _enemyWeaponHandler = GetComponent<EnemyWeaponHandler>();
            _damageReceiver = GetComponent<DamageReceiverView>();
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
            SetVariable(new KeyValuePair<string,AiInput>(AiInputName, _aiInput));
            SetVariable(new KeyValuePair<string,DamageReceiverView>(DamageReceiverName, _damageReceiver));
            SetGlobalVariable(new KeyValuePair<string,WeaponTracker>(WeaponTrackerName, _weaponTracker), new SharedWeaponTracker());
            SetGlobalVariable(new KeyValuePair<string,GameObject>(TargetName, _player.gameObject), new SharedGameObject());
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