using BehaviorDesigner.Runtime.Tasks;
using Modules.PlayerWeaponsHandler;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsArmed")]
    public class IsArmed : Conditional
    {
        private WeaponHandlerView _weaponHandler;

        public override void OnAwake()
        {
            _weaponHandler = GetComponent<WeaponHandlerView>();
        }

        public override TaskStatus OnUpdate()
        {
            return _weaponHandler.WeaponHandlerInfo.CurrentWeaponItemIsEmpty ? TaskStatus.Failure : TaskStatus.Success ;
        }
    }
}