namespace Modules.DamageSystem
{
    public interface IConditionView
    {
        public void UpdateAliveStatus(bool isAlive);
        public void UpdateConsciousStatus(bool isConscious);
        public void UpdateHealth(float value);
    }
}