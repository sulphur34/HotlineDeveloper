using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior
{
    public class BehaviourConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3[] PatrolPoints { get; private set; }
        [field: SerializeField] public float ActionsMinDelay { get; private set; }
        [field: SerializeField] public float ActionsMaxDelay { get; private set; }
        [field: SerializeField] public float ViewDistance { get; private set; }
        [field: SerializeField] public float ViewAngle { get; private set; }
        [field: SerializeField] public float HearingDistance { get; private set; }
        
        
    }
}