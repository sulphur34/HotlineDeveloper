using Modules.Characters;
using Modules.Characters.Enemies.EnemyBehavior.Actions;
using Modules.DamageSystem;
using Modules.MoveSystem;
using Source.Modules.InputSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.CompositeRoot
{
    public class CompositeRoot : LifetimeScope
    {
        [SerializeField] private MoverConfig _moverConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            InputConfigure(builder);
            MoverConfigure(builder);
        }

        private void MoverConfigure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<MoverSetup>();
            builder.RegisterInstance(_moverConfig);
        }

        private void InputConfigure(IContainerBuilder builder)
        {
            builder.Register<TestMoveController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<TestAttackController>(Lifetime.Singleton).AsImplementedInterfaces();
            // builder.Register<MoveToTarget>(Lifetime.Transient).AsImplementedInterfaces();
            // builder.Register<RotateToTarget>(Lifetime.Transient).AsImplementedInterfaces();
            // builder.Register<InputScheme>(Lifetime.Singleton);
            // builder.RegisterComponentInHierarchy<AiInput>().AsImplementedInterfaces();
        }
    }
}