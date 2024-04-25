using System;

namespace Modules.DamageSystem
{
    public interface  IAttackInput
    {
        event Action AttackReceived;
    }
}