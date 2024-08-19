using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Variables;
using UnityEngine;

namespace Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsTargetShotHeard")]
    public class IsTargetShotHeard : Conditional
    {
        public SharedPlayerWeaponHandler PlayerWeaponHandler;
        public SharedBool IsShotFired;
        public float AlertHearingDistance = 10f;

        public override void OnAwake()
        {
            PlayerWeaponHandler.Value.RangeShotFired += OnShotFire;
        }

        public override TaskStatus OnUpdate()
        {
            if (IsShotFired.Value)
            {
                return TaskStatus.Success;
            }

            return TaskStatus.Failure;
        }

        public override void OnBehaviorComplete()
        {
            PlayerWeaponHandler.Value.RangeShotFired -= OnShotFire;
        }

        private void OnShotFire()
        {
            Vector3 targetPosition = PlayerWeaponHandler.Value.transform.position;
            float distance = Vector3.Magnitude(targetPosition - transform.position);

            if (distance <= AlertHearingDistance)
                IsShotFired.Value = true;
        }
    }
}