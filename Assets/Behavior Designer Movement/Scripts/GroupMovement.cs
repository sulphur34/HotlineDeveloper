using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Behavior_Designer_Movement.Scripts
{
    public abstract class GroupMovement : Action
    {
        protected abstract bool SetDestination(int index, Vector3 target);

        protected abstract Vector3 Velocity(int index);
    }
}