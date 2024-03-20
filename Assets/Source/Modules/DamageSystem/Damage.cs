namespace Source.DamageSystem
{
    public class Damage : IDamage
    {
        public Damage(float value, bool isLethal)
        {
            Value = value;
            IsLethal = isLethal;
        }

        public float Value { get; }
        public bool IsLethal { get; }
    }
}