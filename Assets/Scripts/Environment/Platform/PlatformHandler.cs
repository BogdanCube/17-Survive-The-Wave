using System;
using System.Collections;
using System.Collections.Generic;
using Environment.Wave;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Environment.Platform
{
    public class PlatformHandler : MonoBehaviour
    {        
        [SerializeField] private List<Platform> _platforms;
        [SerializeField] private WaveHandler _waveHandler;
        [SerializeField] private NavMeshSurface _navMeshSurface;
        private float _timeMoved;
        
        private void OnEnable()
        {
            _waveHandler.OnAddPlatformEvent += OnAddPlatforms;

        }
        private void OnDisable()
        {
            _waveHandler.OnAddPlatformEvent -= OnAddPlatforms;
        }
        
        private void Start()
        {
            foreach (var platform in _platforms)
            {
                platform.gameObject.SetActive(false);
            }
            
            _navMeshSurface.BuildNavMesh();
        }
        
        [ContextMenu("Add Platform")]
        private void OnAddPlatforms(int levelWave)
        {
            _timeMoved = _waveHandler.TimePreparingWave;

            if (levelWave < _platforms.Count)
            {
                _platforms[levelWave].AddPlatform(_timeMoved);
                StartCoroutine(BakePlatforms());
            }
            /*else
            {
                _waveHandler.PreparingWave();
            }*/
        }

        [ContextMenu("BakePlatforms")]

        private IEnumerator BakePlatforms()
        {
            yield return new WaitForSeconds(_timeMoved);
            _navMeshSurface.BuildNavMesh();
        }
    }
}

