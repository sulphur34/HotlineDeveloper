namespace Source.DamageSystem
{
    public interface IDamage
    {
        public float Value { get; }
        public bool IsLethal { get; }
    }
}