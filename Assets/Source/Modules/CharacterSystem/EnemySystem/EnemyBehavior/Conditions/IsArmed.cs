using BehaviorDesigner.Runtime.Tasks;
using Modules.PlayerWeaponsHandler;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsArmed")]
    public class IsArmed : Conditional
    {
        private WeaponHandler _weaponHandler;

        public override void OnAwake()
        {
            _weaponHandler = GetComponent<WeaponHandler>();
        }

        public override TaskStatus OnUpdate()
        {
            return _weaponHandler.CurrentWeaponItemIsEmpty ? TaskStatus.Failure : TaskStatus.Success ;
        }
    }
}