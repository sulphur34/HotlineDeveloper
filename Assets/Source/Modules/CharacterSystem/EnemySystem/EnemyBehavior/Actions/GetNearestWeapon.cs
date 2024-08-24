using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior.Variables;
using Modules.WeaponItemSystem;
using UnityEngine;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("GetNearestWeapon")]
    public class GetNearestWeapon : Action
    {
        public SharedVector3 LastTargetPosition;
        public SharedWeaponTracker WeaponTracker;
        public SharedBool HasLastPosition;

        private Transform _transform;

        public override void OnAwake()
        {
            _transform = transform;
        }

        public override TaskStatus OnUpdate()
        {
            if (WeaponTracker.Value.TryGetNearest(_transform.position, out WeaponItem weaponItem))
            {
                LastTargetPosition.Value = weaponItem.transform.position;
                HasLastPosition.Value = true;
                return TaskStatus.Success;
            }

            LastTargetPosition.Value = Vector3.zero;
            HasLastPosition.Value = false;
            return TaskStatus.Failure;
        }
    }
}