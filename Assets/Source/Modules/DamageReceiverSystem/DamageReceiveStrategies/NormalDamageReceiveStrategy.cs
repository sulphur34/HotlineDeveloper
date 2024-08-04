namespace Modules.DamageReceiverSystem.DamageStrategy
{
    internal class NormalDamageReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return damageData;
        }
    }
}