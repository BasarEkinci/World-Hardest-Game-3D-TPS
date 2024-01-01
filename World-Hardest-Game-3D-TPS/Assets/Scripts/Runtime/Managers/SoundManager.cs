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

        private void Start()
        {
            _audioSource.clip = audioClips[2];
        }

        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint += OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
            UISignals.Instance.OnButtonCliceked += OnButtonClicked;
        }
        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint -= OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
            UISignals.Instance.OnButtonCliceked -= OnButtonClicked;
        }
        
        private void Update()
        {
            if(!_audioSource.isPlaying)
                _audioSource.Play();
        }
        
        private void OnButtonClicked()
        {
            _audioSource.PlayOneShot(audioClips[4]);
        }

        private void OnGameStart()
        {
            _audioSource.clip = audioClips[3];
        }
        private void OnGameRestart()
        {
            _audioSource.clip = audioClips[2];
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