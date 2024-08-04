namespace Modules.DamageReceiverSystem.DamageStrategy
{
    internal class ImmortalReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
                return DamageData.ZeroDamage;
        }
    }
}