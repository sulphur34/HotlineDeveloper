using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.WeaponsHandler;
using Modules.WeaponsTypes;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("SetAttackDistance")]
    public class SetAttackDistance : Action
    {
        public SharedFloat AttackDistance;
        public float MeleeDistance = 1f;
        public float MangeDistance = 10f;

        private WeaponHandlerView _weaponHandler;

        public override void OnAwake()
        {
            _weaponHandler = GetComponent<WeaponHandlerView>();
        }

        public override TaskStatus OnUpdate()
        {
            if (_weaponHandler == null || _weaponHandler.WeaponInfo.IsCurrentWeaponItemEmpty)
                return TaskStatus.Failure;

            AttackDistance.Value = _weaponHandler.WeaponInfo.CurrentWeaponType == WeaponType.Melee
                ? MeleeDistance
                : MangeDistance;
            return TaskStatus.Success;
        }
    }
}