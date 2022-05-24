using System;
using Core.Character;
using DG.Tweening;
using Core.Character.Behavior;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterAdditions.Health
{
    public class DisplayedHealth : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Image _sliderHp;
        
        [Space(5)][SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private BehaviourSystem _behaviourSystem;

        private void OnEnable()
        {
            _healthComponent.OnHitEvent += OnHit;
            _healthComponent.OnHealEvent += OnHeal;
            _healthComponent.OnDeathEvent += OnDeath;
        }
        
        private void OnDisable()
        { 
            _healthComponent.OnHitEvent -= OnHit;
            _healthComponent.OnHealEvent -= OnHeal;
            _healthComponent.OnDeathEvent -= OnDeath;
        }

        private void Start()
        {
            UpdateHealthBar(_healthComponent.MaxHealth);
        }

        private void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
        }
        private void OnHit(float newHp)
        {
            UpdateHealthBar(newHp);
            _behaviourSystem.SetState(ScriptableObject.CreateInstance<HitState>());
        }

        private void OnHeal(float newHp)
        {
            UpdateHealthBar(newHp);
        }
        private void OnDeath()
        {
            _behaviourSystem.SetState(ScriptableObject.CreateInstance<DeathState>());
            Destroy(_behaviourSystem.gameObject,0.5f);
        }

        private void UpdateHealthBar(float newHp)
        {
            _text.text = Math.Round(newHp).ToString();
            _sliderHp.DOFillAmount((float) newHp / _healthComponent.MaxHealth, 0.3f);
        }
        
    }
}