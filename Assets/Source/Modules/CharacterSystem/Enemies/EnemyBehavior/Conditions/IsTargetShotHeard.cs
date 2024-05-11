using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Source.Modules.CharacterSystem.Enemies.EnemyBehavior.Variables;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsTargetShotHeard")]
    public class IsTargetShotHeard : Conditional
    {
        public SharedPlayerWeaponHandler TargetWeaponHandler;
        public SharedBool IsShotFired;
        public float AlertHearingDistance = 100f;

        public override void OnAwake()
        {
            TargetWeaponHandler.Value.RangeWeaponFired += OnShotFire;
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
            Vector3 _targetPosition = TargetWeaponHandler.Value.transform.position;
            float distance = Vector3.Magnitude(TargetWeaponHandler.Value.transform.position - transform.position);
            
            if (distance <= AlertHearingDistance)
                IsShotFired.Value = true;
        }

        public override void OnBehaviorComplete()
        {
            TargetWeaponHandler.Value.RangeWeaponFired -= OnShotFire;
        }
    }
}