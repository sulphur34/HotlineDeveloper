using Modules.DamageSystem;
using Source.Game.Scripts.Animations;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private RagdollJointData[] _ragdollJointsData;

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