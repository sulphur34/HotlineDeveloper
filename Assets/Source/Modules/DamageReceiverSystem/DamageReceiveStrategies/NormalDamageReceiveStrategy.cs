namespace Modules.DamageReceiverSystem.DamageStrategy
{
    public class NormalDamageReceiveStrategy : IDamageReceiveStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            return damageData;
        }
    }
}