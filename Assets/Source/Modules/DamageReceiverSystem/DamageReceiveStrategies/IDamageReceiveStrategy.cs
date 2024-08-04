namespace Modules.DamageReceiverSystem.DamageStrategy
{
    public interface IDamageReceiveStrategy
    {
        DamageData GetDamage(DamageData damageData);
    }
}