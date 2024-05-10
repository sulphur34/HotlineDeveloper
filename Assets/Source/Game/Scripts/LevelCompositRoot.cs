using Modules.Characters.Enemies.EnemyBehavior;
using Modules.DamageSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Modules.MoveSystem;
using Modules.PlayerWeaponsHandler;
using Modules.Weapons.Ammunition;
using Modules.Weapons.Range;
using Modules.CharacterSystem.Player;
using Source.Modules.DamageSystem;

public class LevelCompositRoot : LifetimeScope
{
    [SerializeField] private MoverConfig _moverConfig;
    [SerializeField] private RangeWeaponConfigFactory _weaponConfigFactory;
    [SerializeField] private WeaponTracker _weaponTracker;
    [SerializeField] private BehaviorConfig _behaviorConfig;
    [SerializeField] private DamageableConfig _damageableConfig;
    

    protected override void Configure(IContainerBuilder builder)
    {
        InputConfigure(builder);
        MoverConfigure(builder);
        WeaponConfigure(builder);
        DamageConfigure(builder);
        EnemyBehaviorConfigure(builder);
    }

    private void EnemyBehaviorConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Player>();
        builder.RegisterInstance(_behaviorConfig);
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

    private void DamageConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<DamageReceiverSetup>();
        builder.RegisterInstance(_damageableConfig);
    } 

    private void WeaponConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<WeaponTracker>();
        builder.RegisterInstance(_weaponConfigFactory);
        builder.RegisterComponentInHierarchy<WeaponAmmunitionView>();
        builder.RegisterComponentInHierarchy<PlayerWeaponHandler>();
        builder.RegisterBuildCallback(container => { container.Resolve<WeaponTracker>().Construct(); });
        builder.RegisterBuildCallback(container => { container.InjectGameObject(_weaponTracker.gameObject); });
    }
}