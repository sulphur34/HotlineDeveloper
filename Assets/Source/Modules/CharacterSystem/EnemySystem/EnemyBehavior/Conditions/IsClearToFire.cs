using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageSystem;
using Modules.PlayerWeaponsHandler;
using Modules.Weapons.WeaponTypeSystem;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
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
            if (_weaponHandler.WeaponHandlerInfo.CurrentWeaponType == WeaponType.Melee)
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