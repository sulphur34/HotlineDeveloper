using BehaviorDesigner.Runtime;
using Modules.DamageReceiverSystem;
using Modules.DamagerSystem;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Variables
{
    public class SharedDamageReceiver : SharedVariable<DamageReceiverView>
    {
        public static implicit operator SharedDamageReceiver(DamageReceiverView value)
        {
            return new SharedDamageReceiver { Value = value };
        }
    }
}