using System;
using System.Collections.Generic;
using Core.Enemy;
using UnityEngine;

namespace Environment.Wave
{
    public class ControllerSpawnEnemy : MonoBehaviour
    {        
        [SerializeField] private WaveHandler _waveHandler;

        private uint _countEnemy;

        public Action<int> OnSpawnEvent;
        public Action<uint> OnUpdateCountEvent;
        private void OnEnable()
        {
            _waveHandler.OnSpawnedEvent += OnSpawned;
        }
        private void OnDisable()
        {
            _waveHandler.OnSpawnedEvent -= OnSpawned;
        }

        private void OnSpawned(int levelEnemy)
        {
            OnSpawnEvent?.Invoke(_waveHandler.LevelEnemy);
        }
        public void CountedEnemy(Enemy enemy)
        {
            _countEnemy++;
            OnUpdateCountEvent?.Invoke(_countEnemy);
            enemy.HealthComponent.OnDeathEvent += RemoveEnemy;
        }

        public void RemoveEnemy()
        {
            _countEnemy--;
            OnUpdateCountEvent?.Invoke(_countEnemy);
            
            if (_countEnemy == 0)
            {
                _waveHandler.PreparingWave();
            }
        }
    }
}