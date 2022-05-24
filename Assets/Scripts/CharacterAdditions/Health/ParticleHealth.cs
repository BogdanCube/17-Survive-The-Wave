using UnityEngine;

namespace CharacterAdditions.Health
{
    public class ParticleHealth : MonoBehaviour
    {
        [SerializeField] protected HealthComponent _healthComponent;

        [Header("Particle")] 
        [SerializeField] private ParticleSystem _particleHit;
        [SerializeField] private ParticleSystem _particleDeath;
        
        private void OnEnable()
        {
            _healthComponent.OnHitEvent += OnPlayedHit;
            _healthComponent.OnDeathEvent += OnPlayedDeath;
        }

        private void OnDisable()
        {
            _healthComponent.OnHitEvent -= OnPlayedHit;
            _healthComponent.OnDeathEvent -= OnPlayedDeath;
        }

        private void OnPlayedHit(float newHp)
        {
            _particleHit.gameObject.SetActive(true);
        }
        
        private void OnPlayedDeath()
        {
            _particleDeath.gameObject.SetActive(true);
        }
    }
}