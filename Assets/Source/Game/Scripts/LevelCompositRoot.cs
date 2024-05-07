using Modules.FadeSystem;
using Modules.LevelsSystem;
using Modules.PauseMenu;
using Modules.PlayerWeaponsHandler;
using Modules.SaveHandlers;
using Modules.Weapons.Ammunition;
using Modules.Weapons.InputSystem;
using Modules.Weapons.Range;
using Modules.Weapons.WeaponItemSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LevelCompositRoot : LifetimeScope
{
    [SerializeField] private RangeWeaponConfigFactory _weaponConfigFactory;
    [SerializeField] private GameObject _weaponSetupsParent;

    protected override void OnDestroy()
    {
        Dispose();
    }

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_weaponConfigFactory);
        builder.RegisterComponentInHierarchy<WeaponAmmunitionView>();
        builder.RegisterEntryPoint<ShotDesktopInput>().As<IShotInput>();
        builder.RegisterEntryPoint<DesktopWeaponItemInput>().As<IWeaponItemInput>();
        builder.RegisterComponentInHierarchy<PlayerWeaponHandler>();

        builder.RegisterComponentInHierarchy<LevelHandler>();
        builder.Register<LevelSaveHandler>(Lifetime.Singleton);

        builder.Register<PauseSetter>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<LoadSceneButton>();
        builder.RegisterComponentInHierarchy<RestartLevelButton>();

        builder.RegisterBuildCallback(container =>
        {
            container.InjectGameObject(_weaponSetupsParent);
            container.Resolve<LevelSaveHandler>();
            container.Resolve<Fade>().Out();
        });
    }
}