using System;
using UnityEngine;

namespace CharacterAdditions.Health
{
    public class HealthComponent : MonoBehaviour
    {        
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;
        public event Action<float> OnHitEvent;
        public event Action<float> OnHealEvent;
        public event Action OnRepeatHealEvent;
        public event Action OnDeathEvent;
        
        public float CurrentHealth => _currentHealth;
        public float MaxHealth  => _maxHealth;
        public bool IsDeath => _currentHealth <= 0;
        public bool IsHalfHealth => _currentHealth <= 0.75f * _maxHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void Heal(float healHealth)
        {
            _currentHealth += healHealth;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            OnHealEvent?.Invoke(_currentHealth);
        }
        public void Hit(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                OnDeathEvent?.Invoke();
            }
            OnHitEvent?.Invoke(_currentHealth);        
            OnRepeatHealEvent?.Invoke();        
        }
        public void IncreaseMaxHealth(float additionalHealth)
        {
            _maxHealth += additionalHealth;
            _currentHealth = _maxHealth;
            Heal(200);
        }

        [ContextMenu("Hit")]
        public void HitByOne()
        {
            Hit(10);
        }
    }
}