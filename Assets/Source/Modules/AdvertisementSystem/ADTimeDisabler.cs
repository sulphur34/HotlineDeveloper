using System.Collections;
using UnityEngine;

namespace Modules.AdvertisementSystem
{
    public class ADTimeDisabler : MonoBehaviour
    {
        [SerializeField] private float _disableDelay;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_disableDelay);
            gameObject.SetActive(false);
        }
    }
}