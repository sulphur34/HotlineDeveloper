using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using Modules.DamagerSystem;
using Modules.WeaponsHandler;
using Modules.WeaponTypes;
using UnityEngine;

namespace Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsClearToFire")]
    public class IsClearToFire : Conditional
    {
        public SharedFloat AttackDistance;
        public float FireAngle = 15f;
        
        private Transform _transform;
        private WeaponHandlerView _weaponHandler;
        private Enemy _selfEnmey;

        public override void OnAwake()
        {
            _transform = transform;
            _weaponHandler = GetComponent<WeaponHandlerView>();
            _selfEnmey = GetComponent<Enemy>();
        }

        public override TaskStatus OnUpdate()
        {
            if (_weaponHandler.WeaponInfo == null)
                return TaskStatus.Success;
            
            if (_weaponHandler.WeaponInfo.CurrentWeaponType == WeaponType.Melee)
                return TaskStatus.Success;

            var enemy = Physics
                .OverlapSphere(transform.position, AttackDistance.Value)
                .Select(collider => collider.GetComponent<Enemy>())
                .Where(collider => collider?.GetComponent<DamageReceiverView>().IsDead == false)
                .FirstOrDefault(enemy => enemy != null && enemy != _selfEnmey && IsInFireZone(enemy));
            
            return enemy == null ? TaskStatus.Success : TaskStatus.Failure;
        }

        private bool IsInFireZone(Enemy enemy)
        {
            Vector3 directionToAlly = enemy.transform.position - _transform.position;
            return Vector3.Angle(directionToAlly, _transform.forward) < FireAngle;
        }
    }
}