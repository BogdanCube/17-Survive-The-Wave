using System;
using Core.Player;
using DG.Tweening;
using Environment.Wave;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PanelGameOver : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Image _panel;
        [SerializeField] private Text _textRecord;

        [SerializeField] private WaveHandler _waveHandler;
        private void OnEnable()
        {
            _player.HealthComponent.OnDeathEvent += OnShowPanel;
        }

        private void OnDisable()
        {
            _player.HealthComponent.OnDeathEvent -= OnShowPanel;
        }

        private void OnShowPanel()
        {
            _panel.gameObject.SetActive(true);
            _textRecord.text = _waveHandler.LevelWave.ToString();
            Time.timeScale = 0;
        }

        public void Restart()
        {
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}