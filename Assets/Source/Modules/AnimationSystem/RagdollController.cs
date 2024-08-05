using Modules.AnimationSystem;
using UnityEngine;

internal class RagdollController
{
    private RagdollJointData[] _ragdollJointsData;
    private Transform _hipBonePosition;

    internal RagdollController(RagdollJointData[] ragdollJointsData)
    {
        _ragdollJointsData = ragdollJointsData;
        Deactivate();
    }

    internal void Activate()
    {
        SetStatus(true);
    }

    internal void Deactivate()
    {
        SetStatus(false);
    }

    private void SetStatus(bool isActive)
    {
        foreach (RagdollJointData ragdollJointData in _ragdollJointsData)
        {
            ragdollJointData.Rigidbody.isKinematic = !isActive;
            ragdollJointData.Rigidbody.useGravity = isActive;
            ragdollJointData.Collider.enabled = isActive;
        }
    }
}