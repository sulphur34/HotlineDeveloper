using System;

namespace Modules.Ammunition
{
    public class WeaponAmmunition
    {
        public WeaponAmmunition(uint count)
        {
            Count = count;
        }

        internal event Action CountChanged;

        public uint Count { get; private set; }

        public void Remove()
        {
            if (Count > 0)
            {
                Count--;
                CountChanged?.Invoke();
            }
        }
    }
}