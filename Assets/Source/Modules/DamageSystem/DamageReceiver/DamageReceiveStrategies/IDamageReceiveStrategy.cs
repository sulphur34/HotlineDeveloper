using Modules.DamageSystem;

namespace Modules.DamageSystem.DamageStrategy
{
    public interface IDamageReceiveStrategy
    {
        DamageData GetDamage(DamageData damageData);
    }
}