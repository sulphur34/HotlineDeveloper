using BehaviorDesigner.Runtime;
using UnityEngine;

namespace Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Variables
{
    public class SharedVector3Array : SharedVariable<Vector3[]>
    {
        public static implicit operator SharedVector3Array(Vector3[] value)
        {
            return new SharedVector3Array { Value = value };
        }
    }
}