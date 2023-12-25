using System.Collections;
using System.Collections.Generic;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint += OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }
        private void Start()
        {
            StartCoroutine(LoadAndPlayMusic(audioClips[2]));
        }
        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint -= OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
        }

        private void OnGameStart()
        {
            StartCoroutine(LoadAndPlayMusic(audioClips[3]));
        }
        private void OnGameRestart()
        {
            StartCoroutine(LoadAndPlayMusic(audioClips[2]));
        }
        private void OnPlayerCollectPoint()
        {
            _audioSource.PlayOneShot(audioClips[0]);
        }
        private void OnPlayerCrash()
        {
            _audioSource.PlayOneShot(audioClips[1]);
        }
        
        private IEnumerator LoadAndPlayMusic(AudioClip musicClip)
        {
            var request = Resources.LoadAsync<AudioClip>($"Sounds/{musicClip.name}");
            
            while (!request.isDone)
            {
                yield return null;
            }
            _audioSource.clip = (AudioClip)request.asset;
            _audioSource.Play();
        }
    }   
}