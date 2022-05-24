using System;
using UnityEngine;
using UnityEngine.UI;

namespace Environment.Wave
{
    public class DisplayedCountEnemy : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private ControllerSpawnEnemy _controllerSpawnEnemy;
        private void OnEnable()
        {
            _controllerSpawnEnemy.OnUpdateCountEvent += OnUpdateCount;
        }

        private void OnDisable()
        {
            _controllerSpawnEnemy.OnUpdateCountEvent -= OnUpdateCount;
        }

        private void OnUpdateCount(uint count)
        {
            _text.text = count.ToString();
        }
    }
}