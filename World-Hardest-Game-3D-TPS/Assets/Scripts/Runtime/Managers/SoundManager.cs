using System.Collections.Generic;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource[] _audios;

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }
        private void Awake()
        {
            _audios = GetComponentsInChildren<AudioSource>();
        }
        private void Start()
        {
            _audios[0].Play();
        }
        private void OnDisable()
        {
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
        }
        private void OnGameRestart()
        {
            _audios[1].Stop();
            _audios[0].Play();
        }
        private void OnGameStart()
        {
            _audios[0].Stop();
            _audios[1].Play();
        }
    }   
}