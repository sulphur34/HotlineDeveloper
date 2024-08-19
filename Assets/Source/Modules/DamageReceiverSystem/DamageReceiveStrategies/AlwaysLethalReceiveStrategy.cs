namespace Modules.DamagerSystem.DamageStrategy
{
    internal class AlwaysLethalReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return DamageData.ExecutionDamage;
        }
    }
}