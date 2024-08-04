namespace Modules.DamageReceiverSystem.DamageStrategy
{
    internal interface IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData);
    }
}