using System;
using VContainer;
using Object = UnityEngine.Object;

namespace Modules.Items.Weapons
{
    public class Weapon : IDisposable
    {
        private readonly BulletConfig _bulletConfig;
        private readonly ShotDesktopInput _input;

        [Inject]
        internal Weapon(BulletConfigFabric fabric, ShotDesktopInput input)
        {
            _bulletConfig = fabric.Get(this);
            _input = input;
            _input.Received += OnReceived;
        }

        public void Dispose()
        {
            _input.Received -= OnReceived;
        }

        private void Shot()
        {
            Bullet bullet = Object.Instantiate(_bulletConfig.Prefab);
            bullet.Init(_bulletConfig.Speed);
        }

        private void OnReceived()
        {
            Shot();
        }
    }
}