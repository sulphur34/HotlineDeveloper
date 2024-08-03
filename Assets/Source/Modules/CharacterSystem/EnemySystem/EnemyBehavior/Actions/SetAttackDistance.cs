using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.PlayerWeaponsHandler;
using Modules.Weapons.WeaponTypeSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
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
            if (_weaponHandler == null || _weaponHandler.WeaponInfo.CurrentWeaponItemIsEmpty)
                return TaskStatus.Failure;

            AttackDistance.Value = _weaponHandler.WeaponInfo.CurrentWeaponType == WeaponType.Melee
                ? MeleeDistance
                : MangeDistance;
            return TaskStatus.Success;
        }
    }
}