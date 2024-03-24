using System;

namespace Modules.Items.ItemPickSystem
{
    public interface IItemSelectionInput
    {
        event Action Received;
    }
}
