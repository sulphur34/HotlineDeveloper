namespace Modules.DamageReceiverSystem.DamageStrategy
{
    internal class AlwaysLethalReceiveStrategy: IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return DamageData.ExecutionDamage;
        }
    }
}