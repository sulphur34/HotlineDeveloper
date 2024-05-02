using Modules.DamageSystem;

namespace Modules.DamageSystem.DamageStrategy
{
    public interface IDamageStrategy
    {
        DamageData GetDamage(DamageData damageData);
    }
}