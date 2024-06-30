namespace Modules.DamageSystem.DamageStrategy
{
    public class ImmortalReceiveStrategy : IDamageReceiveStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
                return DamageData.ZeroDamage;
        }
    }
}