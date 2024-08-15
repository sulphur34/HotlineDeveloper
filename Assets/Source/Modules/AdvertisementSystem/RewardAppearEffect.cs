using UnityEngine;

namespace Modules.AdvertisementSystem
{
    public class RewardAppearEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _appearEffect;

        private ParticleSystem _effectInstance;

        private void Awake()
        {
            gameObject.SetActive(false);
        }
        
        private void OnEnable()
        {
            _effectInstance = Instantiate(_appearEffect, transform.position, Quaternion.identity);
            _effectInstance.Play();
        }

        private void OnDisable()
        {
            _effectInstance.Stop();
        }
    }
}