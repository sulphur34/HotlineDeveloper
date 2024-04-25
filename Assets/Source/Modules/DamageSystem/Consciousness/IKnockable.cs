using System;

namespace Modules.DamageSystem
{
    public interface IKnockable
    {
        public event Action Recovered;
        public event Action Knocked;
        public void Knockout();
    }
}