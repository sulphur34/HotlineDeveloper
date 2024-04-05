namespace Modules.DamageSystem
{
    public interface IDamageable 
    {
        void TakeDamage(float damage);

        void Execute();
    }
}