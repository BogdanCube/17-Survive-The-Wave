using System;
using System.Collections.Generic;
using Core.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Environment.Wave
{
    public enum EnemyType {Zombie, Skeleton}
    public class SpawnPointEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private ControllerSpawnEnemy _controlSpawnEnemy;
        
        [Space] [SerializeField] private List<Enemy> _enemies;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private List<Mesh> _meshes;
        [SerializeField] private MeshFilter _meshFilter;

        private void OnEnable()
        {
            _controlSpawnEnemy.OnSpawnEvent += OnSpawn;
        }

        private void OnDisable()
        {
            _controlSpawnEnemy.OnSpawnEvent -= OnSpawn;
        }

        private void OnValidate()
        {
            _meshFilter.mesh = _meshes[(int) _enemyType];
        }

        private void OnSpawn(int levelEnemy)
        {
            Enemy enemy = Instantiate(_enemies[(int) _enemyType], transform.position, Quaternion.identity);
            enemy.LevelEquipment.SetEquipment(levelEnemy);
            
            _controlSpawnEnemy.CountedEnemy(enemy);
            
            _particleSystem.gameObject.SetActive(true);
        }
    }
}