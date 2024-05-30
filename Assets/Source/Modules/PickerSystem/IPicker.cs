using System;
using UnityEngine;

namespace Modules.PickerSystem
{
    public interface IPicker
    {
        event Action<Transform> Picked;

        void Pick();
    }
}