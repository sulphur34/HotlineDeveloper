namespace Modules.DamagerSystem.DamageStrategy
{
    internal class NormalDamageReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return damageData;
        }
    }
}