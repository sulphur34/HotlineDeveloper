using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.Enemies.EnemyBehavior.Variables;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsTargetShotHeard")]
    public class IsTargetShotHeard : Conditional
    {
        public SharedPlayerWeaponHandler PlayerWeaponHandler;
        public SharedBool IsShotFired;
        public float AlertHearingDistance = 100f;

        public override void OnAwake()
        {
            PlayerWeaponHandler.Value.RangeWeaponFired += OnShotFire;
        }
        
        public override TaskStatus OnUpdate()
        {
            if (IsShotFired.Value)
            {
                return TaskStatus.Success;
            }

            return TaskStatus.Failure;
        }
        
        private void OnShotFire()
        {
            Vector3 _targetPosition = PlayerWeaponHandler.Value.transform.position;
            float distance = Vector3.Magnitude(PlayerWeaponHandler.Value.transform.position - transform.position);
            
            if (distance <= AlertHearingDistance)
                IsShotFired.Value = true;
        }

        public override void OnBehaviorComplete()
        {
            PlayerWeaponHandler.Value.RangeWeaponFired -= OnShotFire;
        }
    }
}