using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Environment.Wave
{
    public class DisplayedWave : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Image _slider;

        [SerializeField] private Color _colorPreparation;
        [SerializeField] private Color _colorStartWave;
        
        [SerializeField] private WaveHandler _waveHandler;

        private void OnEnable()
        {
            _waveHandler.OnStartWaveEvent += OnPreparationTime;
            _waveHandler.OnSetWaveEvent += OnSetWave;
        }
        private void OnDisable()
        {
            _waveHandler.OnStartWaveEvent -= OnPreparationTime;
            _waveHandler.OnSetWaveEvent -= OnSetWave;
        }

        private void OnPreparationTime()
        {
            _slider.DOKill();
            _slider.fillAmount = 1;
            _slider.color = _colorPreparation;
            _slider.DOFillAmount(0, _waveHandler.TimePreparingWave);
        }
        private void OnSetWave(int currentLevelWave, float timeWave)
        {            
            _slider.DOKill();
            _text.text = currentLevelWave.ToString();
            _slider.fillAmount = 1;
            _slider.color = _colorStartWave;
            _slider.DOFillAmount(0, timeWave)
                .OnComplete(() => _waveHandler.PreparingWave());
        }
    }
}