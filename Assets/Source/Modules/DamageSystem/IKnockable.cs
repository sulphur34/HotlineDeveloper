using System;

namespace Modules.DamageSystem
{
    internal interface IKnockable
    {
        public event Action Recovered;
        public void Knockout();
    }
}