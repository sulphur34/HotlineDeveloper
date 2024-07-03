using Source.Game.Scripts.Animations;
using UnityEngine;

internal class RagdollController
{
    private RagdollJointData[] _ragdollJointsData;
    private Transform _hipBonePosition;

    public RagdollController(RagdollJointData[] ragdollJointsData)
    {
        _ragdollJointsData = ragdollJointsData;
        Deactivate();
    }

    public void Activate()
    {
        SetStatus(true);
    }

    public void Deactivate()
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