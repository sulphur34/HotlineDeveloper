using BehaviorDesigner.Runtime.Tasks;
using Modules.WeaponsHandler;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Conditions
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
            if (_weaponHandler.WeaponInfo == null)
                return TaskStatus.Failure;

            return _weaponHandler.WeaponInfo.IsCurrentWeaponItemEmpty ? TaskStatus.Failure : TaskStatus.Success;
        }
    }
}