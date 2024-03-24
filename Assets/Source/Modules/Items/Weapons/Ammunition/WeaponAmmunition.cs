using System;

namespace Modules.Items.Weapons.Ammunition
{
    internal class WeaponAmmunition
    {
        internal WeaponAmmunition(uint count)
        {
            Count = count;
        }

        internal event Action CountChanged;

        internal uint Count { get; private set; }

        internal void Remove()
        {
            if (Count > 0)
            {
                Count--;
                CountChanged?.Invoke();
            }
        }
    }
}