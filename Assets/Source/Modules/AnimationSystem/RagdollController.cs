namespace Modules.AnimationSystem
{
    internal class RagdollController
    {
        private readonly RagdollJointData[] _ragdollJointsData;

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
}