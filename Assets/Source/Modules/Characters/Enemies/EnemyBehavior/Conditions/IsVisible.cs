using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [Condition("CustomBehaviour/IsVisible")]
    public class IsVisible : GOCondition
    {
        [InParam("target")]
        private GameObject target;
       
        [InParam("angle")]
        private float angle;
        
        [InParam("closeDistance")]
        private float closeDistance;

        public override bool Check()
        {
            Vector3 direction = target.transform.position - gameObject.transform.position;
            
            if (direction.sqrMagnitude > closeDistance * closeDistance)
                return false;
            
            bool isClose = direction.sqrMagnitude <= closeDistance;

            RaycastHit hit;
            if (Physics.Linecast(gameObject.transform.position, target.transform.position, out hit))
            {
                Debug.DrawRay(gameObject.transform.position, target.transform.position, Color.red);
                float diffAngle = Vector3.Angle(direction, gameObject.transform.forward);
                bool isVisible = hit.collider.gameObject == target && diffAngle < angle * 0.5f;
                
                Debug.Log(direction.magnitude + " " + isClose + "-" + diffAngle + " " + isVisible);
                return isVisible;
            }
            
            return false;
        }
    }
}