using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;
        [SerializeField] private AudioSource[] audioSources;
        
        private bool _isMusicOn = true;
        
        private void Start()
        {
            audioSources[0].clip = audioClips[2];
        }

        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint += OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
            UISignals.Instance.OnButtonCliceked += OnButtonClicked;
        }
        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint -= OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
            UISignals.Instance.OnButtonCliceked -= OnButtonClicked;
        }
        
        private void Update()
        {
            if(!audioSources[0].isPlaying)
                audioSources[0].Play();
        }
        
        public void SetMusicState(bool isOn)
        {
            audioSources[0].volume = isOn ? 1 : 0;
        }
        
        private void OnLevelComplete()
        {
            audioSources[1].PlayOneShot(audioClips[6]);
        }
        
        private void OnButtonClicked()
        {
            audioSources[1].PlayOneShot(audioClips[4]);
        }

        private void OnGameStart()
        {
            audioSources[0].clip = audioClips[3];
        }
        private void OnGameRestart()
        {
            audioSources[0].clip = audioClips[2];
        }
        private void OnPlayerCollectPoint()
        {
            audioSources[1].PlayOneShot(audioClips[0]);
        }
        private void OnPlayerCrash()
        {
            audioSources[1].PlayOneShot(audioClips[1]);
        }
    }   
}