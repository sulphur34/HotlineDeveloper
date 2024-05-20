using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.PlayerWeaponsHandler;
using Modules.Weapons.WeaponTypeSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    // [TaskCategory("CustomTask")]
    // [TaskName("SetAttackDistance")]
    // public class SetAttackDistance : Action
    // {
    //     public SharedFloat AttackDistance;
    //
    //     private readonly float _meleeAttackDistance = 1f;
    //     private readonly float _rangAttackDistance = 40f;
    //     
    //     private WeaponHandler _weaponHandler;
    //     
    //
    //     public override void OnAwake()
    //     {
    //         _weaponHandler = GetComponent<WeaponHandler>();
    //     }
    //
    //     public override TaskStatus OnUpdate()
    //     {
    //         if (_weaponHandler == null || _weaponHandler.CurrentWeaponItemIsEmpty)
    //             return TaskStatus.Failure;
    //
    //         AttackDistance.Value = _weaponHandler.CurrentWeaponType == WeaponType.Melee ? _meleeAttackDistance : _rangAttackDistance;
    //         return TaskStatus.Success;
    //     }
    // }
}