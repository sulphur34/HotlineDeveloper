using System;

namespace Modules.DamageSystem
{
    public interface IKnockable
    {
        public event Action Recovered;
        public event Action Knoked;
        public void Knockout();
    }
}