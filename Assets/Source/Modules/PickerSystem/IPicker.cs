using System;

namespace Modules.PickerSystem
{
    public interface IPicker
    {
        event Action<IPickable> Picked;

        void Pick();
    }
}