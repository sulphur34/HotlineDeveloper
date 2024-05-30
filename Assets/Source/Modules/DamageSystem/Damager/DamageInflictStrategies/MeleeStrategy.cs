namespace Modules.DamageSystem
{
    public class MeleeStrategy : WeaponStrategy
    {
        public override void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            if (OwnerDamageReceiver == null)
                return;
            
            if(damageReceiverView != OwnerDamageReceiver)
                damageReceiverView.Receive(damageData);
        }
    }
}