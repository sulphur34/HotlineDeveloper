using System;

namespace Modules.Items.Weapons
{
    internal interface IAttacker
    {
        event Action Attacked;

        void Attack();
    }
}