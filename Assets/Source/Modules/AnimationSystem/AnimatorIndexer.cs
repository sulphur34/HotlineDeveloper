using UnityEngine;

namespace Modules.AnimationSystem
{
    internal class AnimatorIndexer
    {
        private const string TwoHandsAttackName = "TwoHandsAttack";
        private const string OneHandAttackName = "OneHandAttack";
        private const string BareHandsAttack = "BareHandsAttack";
        private const string SpeedName = "Speed";

        internal AnimatorIndexer()
        {
            TwoHandsAttackIndex = Animator.StringToHash(TwoHandsAttackName);
            BareHandsAttackIndex = Animator.StringToHash(BareHandsAttack);
            OneHandAttackIndex = Animator.StringToHash(OneHandAttackName);
            SpeedIndex = Animator.StringToHash(SpeedName);
        }

        internal int TwoHandsAttackIndex { get; }

        internal int OneHandAttackIndex { get; }

        internal int BareHandsAttackIndex { get; }

        internal int SpeedIndex { get; }
    }
}