namespace Modules.DamagerSystem.DamageStrategy
{
    internal class ImmortalReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
                return DamageData.ZeroDamage;
        }
    }
}