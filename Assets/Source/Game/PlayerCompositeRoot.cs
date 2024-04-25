using Modules.DamageSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Modules.MoveSystem;
using Modules.PlayerWeaponsHandler;
using Modules.Weapons.Ammunition;
using Modules.Weapons.Range;

public class PlayerCompositeRoot : LifetimeScope
{
    [SerializeField] private MoverConfig _moverConfig;
    [SerializeField] private HealthConfig _healthConfig;
    [SerializeField] private ConsciousnessConfig _consciousnessConfig;
    [SerializeField] private RangeWeaponConfigFactory _weaponConfigFactory;
    [SerializeField] private GameObject _weaponSetupsParent;

    protected override void Configure(IContainerBuilder builder)
    {
        InputConfigure(builder);
        MoverConfigure(builder);
        WeaponConfigure(builder);
        // ConsciounessConfigure(builder);
        // HealthConfigure(builder);
    }

    private void MoverConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<MoverSetup>();
        builder.RegisterInstance(_moverConfig);
    }

    private void InputConfigure(IContainerBuilder builder)
    {
        if (Application.isMobilePlatform)
            builder.RegisterComponentOnNewGameObject<MobileInputController>(Lifetime.Scoped, "MobileInputController")
                .AsImplementedInterfaces();
        else
            builder.RegisterComponentOnNewGameObject<DesktopInputController>(Lifetime.Scoped, "DesktopInputController")
                .AsImplementedInterfaces();
    }

    private void HealthConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Health>();
        builder.RegisterInstance(_healthConfig);
    }

    private void ConsciousnessConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Health>();
        builder.RegisterInstance(_consciousnessConfig);
    }

    private void WeaponConfigure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_weaponConfigFactory);
        builder.RegisterComponentInHierarchy<WeaponAmmunitionView>();
        // builder.RegisterEntryPoint<ShotDesktopInput>().As<IShotInput>();
        // builder.RegisterEntryPoint<DesktopWeaponItemInput>().As<IWeaponItemInput>();
        builder.RegisterComponentInHierarchy<PlayerWeaponHandler>();

        builder.RegisterBuildCallback(container => { container.InjectGameObject(_weaponSetupsParent); });
    }
}