namespace Modules.DamagerSystem.DamageStrategy
{
    internal enum DamageReceiveStrategies
    {
        KnockoutImmune,
        MeleeImmune,
        AlwaysLethal,
        Normal,
        Immortal,
        LethalAsNormal
    }
}