using System.Collections;
using UnityEngine;

namespace Modules.Items.Weapons.Melee
{
    public class MeleeWeaponView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _rotationTime;
        [SerializeField] private float _rotateAngle;

        public void Animate()
        {
            StartCoroutine(StartRotate());
        }

        private IEnumerator StartRotate()
        {
            float elapsedTime = 0;
            Quaternion startRotation = Quaternion.Euler(0, -_rotateAngle, 0);
            Quaternion targetRotation = Quaternion.Euler(0, _rotateAngle, 0);

            _transform.rotation = startRotation;

            while (elapsedTime <= _rotationTime) 
            {
                elapsedTime += Time.deltaTime;
                _transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / _rotationTime);
                yield return null;
            }
        }
    }
}