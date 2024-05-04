using BehaviorDesigner.Runtime;
using Source.Modules.DamageSystem;

namespace Modules.DamageSystem.Enemies.EnemyBehavior.Variables
{
    public class SharedDamageReceiver : SharedVariable<DamageReceiverView>
    {
        public static implicit operator SharedDamageReceiver(DamageReceiverView value) { return new SharedDamageReceiver { Value = value }; }
    }
}