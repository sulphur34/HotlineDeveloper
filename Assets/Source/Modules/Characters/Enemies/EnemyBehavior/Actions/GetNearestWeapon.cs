using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class GetNearestWeapon : Action
    {
        public SharedVector3 LastTargetPosition;

        public override void OnAwake()
        {
            
        }

        public override TaskStatus OnUpdate()
        {
            return base.OnUpdate();
        }

        
    }
}