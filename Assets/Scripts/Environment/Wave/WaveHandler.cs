using System;
using System.Collections;
using System.Collections.Generic;
using CharacterAdditions.Health;
using UnityEngine;

namespace Environment.Wave
{
    public class WaveHandler : MonoBehaviour
    {
        [SerializeField] [Range(0, 3)] private int _levelEnemy;
        [SerializeField] private int _levelWave;
        [SerializeField] private float _timeWave;
        [SerializeField] private float _timePreparingWave;
        
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private List<TemplateWave> _templateWaves;

        public Action<int,float> OnSetWaveEvent;
        public Action<int> OnAddPlatformEvent;
        public Action OnStartWaveEvent;
        public Action<int> OnSpawnedEvent;

        public int LevelEnemy => _levelEnemy;
        public float TimePreparingWave => _timePreparingWave;
        public int LevelWave =>_levelWave;

        

        [ContextMenu("PreparingWave")]
        public void PreparingWave()
        {
            Load();
            _healthComponent.Heal(200);
            OnStartWaveEvent?.Invoke();
            OnAddPlatformEvent?.Invoke(_levelWave);

            StartCoroutine(StartNextWave());
        }
        private IEnumerator StartNextWave()
        {
            yield return new WaitForSeconds(_timePreparingWave);
            OnSetWaveEvent?.Invoke(_levelWave,_timeWave);
            OnSpawnedEvent?.Invoke(_levelEnemy);
        }

        private void Load()
        {
            _levelWave++;
            foreach (var template in _templateWaves)
            {
                if (_levelWave == template.LevelWave)
                {
                    _levelEnemy = template.LevelEnemy;
                    _timeWave = template.TimeWave;
                    _timePreparingWave = template.TimePreparingWave;
                }
            }
        }
    }
    [System.Serializable]
    public struct TemplateWave
    {
        public int LevelWave;
        [Range(0,3)] public int LevelEnemy;
        public int TimeWave;
        public int TimePreparingWave;
    }
}