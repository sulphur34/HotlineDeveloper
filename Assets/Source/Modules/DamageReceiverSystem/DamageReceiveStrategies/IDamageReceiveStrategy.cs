namespace Modules.DamagerSystem.DamageStrategy
{
    internal interface IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData);
    }
}