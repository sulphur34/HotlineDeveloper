namespace Modules.DamageReceiverSystem.DamageStrategy
{
    public class AlwaysLethalReceiveStrategy: IDamageReceiveStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            return DamageData.ExecutionDamage;
        }
    }
}