using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;
        private AudioSource[] _audios;
        private AudioSource _soundEffects;
        
        private void Awake()
        {
            _audios = GetComponentsInChildren<AudioSource>();
            _soundEffects = GetComponent<AudioSource>();
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
            _audios[0].Play();
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
            _audios[1].Play();
            _audios[0].Stop();
        }
        private void OnGameRestart()
        {
            _audios[0].Play();
            _audios[1].Stop();
        }
        private void OnPlayerCollectPoint()
        {
            _soundEffects.PlayOneShot(audioClips[0]);
        }
        private void OnPlayerCrash()
        {
            _soundEffects.PlayOneShot(audioClips[1]);
        }
    }   
}