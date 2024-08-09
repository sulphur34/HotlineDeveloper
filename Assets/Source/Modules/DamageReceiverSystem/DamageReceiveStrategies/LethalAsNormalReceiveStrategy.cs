namespace Modules.DamagerSystem.DamageStrategy
{
    internal class LethalAsNormalReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return damageData.IsLethal ? DamageData.RangeDamage : DamageData.ZeroDamage;
        }
    }
}