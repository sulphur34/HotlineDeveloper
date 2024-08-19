namespace Modules.DamagerSystem
{
    internal class RangeStrategy : WeaponStrategy
    {
        public override void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            if (OwnerDamageReceiver == null || IsEquipped)
                return;

            if (damageReceiverView != OwnerDamageReceiver)
                damageReceiverView.Receive(damageData);
        }
    }
}