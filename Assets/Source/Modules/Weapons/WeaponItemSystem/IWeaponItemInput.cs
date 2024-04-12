using System;

namespace Modules.WeaponItemSystem
{
    public interface IWeaponItemInput
    {
        public event Action Received;
    }
}