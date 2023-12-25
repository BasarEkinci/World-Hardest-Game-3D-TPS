using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;
        private AudioSource[] _audios;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audios = GetComponentsInChildren<AudioSource>();
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
            _audioSource.clip = audioClips[2];
            _audioSource.Play();
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
            _audioSource.clip = audioClips[3];
            _audioSource.Play();
        }
        private void OnGameRestart()
        {
            _audioSource.clip = audioClips[2];
            _audioSource.Play();
        }
        private void OnPlayerCollectPoint()
        {
            _audioSource.PlayOneShot(audioClips[0]);
        }
        private void OnPlayerCrash()
        {
            _audioSource.PlayOneShot(audioClips[1]);
        }
    }   
}