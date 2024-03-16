using System;

namespace Modules.Items.ItemPickSystem
{
    public interface IPickable
    {
        event Action Picked;
    }
}
