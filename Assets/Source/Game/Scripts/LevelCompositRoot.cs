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
using Modules.EnemySpawnSystem;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using Modules.InputSystem;

public class LevelCompositRoot : LifetimeScope
{
    [SerializeField] private MoverConfig _moverConfig;
    [SerializeField] private RangeWeaponConfigFactory _weaponConfigFactory;
    [SerializeField] private WeaponTracker _weaponTracker;
    [SerializeField] private LevelEnemySpawnConfigs _enemySpawnConfigs;
    [SerializeField] private BehaviorConfigFactory _behaviorConfigFactory;
    [SerializeField] private DamageableConfigFactory _damageableConfigFactory;

    protected override void Configure(IContainerBuilder builder)
    {
        InputConfigure(builder);
        MoverConfigure(builder);
        WeaponConfigure(builder);
        DamageConfigure(builder);
        EnemyConfigure(builder);
    }

    private void EnemyConfigure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_enemySpawnConfigs);
        builder.RegisterInstance(_behaviorConfigFactory);
        builder.RegisterComponentInHierarchy<Player>();
        builder.RegisterComponentInHierarchy<EnemySpawner>();
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
        builder.RegisterInstance(_damageableConfigFactory.GetConfig(DamageableTypes.Player));
        builder.RegisterInstance(_damageableConfigFactory);
        builder.RegisterComponentInHierarchy<DamageReceiverSetup>();
    } 

    private void WeaponConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<WeaponTracker>();
        builder.RegisterInstance(_weaponConfigFactory);
        builder.RegisterComponentInHierarchy<WeaponAmmunitionView>();
        builder.RegisterComponentInHierarchy<PlayerWeaponHandlerSetup>();
        builder.RegisterBuildCallback(container => { container.Resolve<WeaponTracker>().Construct(); });
        builder.RegisterBuildCallback(container => { container.InjectGameObject(_weaponTracker.gameObject); });
    }
}