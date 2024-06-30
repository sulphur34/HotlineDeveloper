namespace Modules.DamageSystem.DamageStrategy
{
    public class LethalAsNormalReceiveStrategy : IDamageReceiveStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            return damageData.IsLethal ? DamageData.RangeDamage : DamageData.ZeroDamage;
        }
    }
}