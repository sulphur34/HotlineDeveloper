using Modules.DamageSystem;

namespace Source.Modules.DamageSystem
{
    public interface IDamageReceiver
    {
        void Receive(DamageData damageData);
    }
}