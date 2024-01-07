using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;
        [SerializeField] private AudioSource audioSource;
        
        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint += OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
        }
        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint -= OnPlayerCollectPoint;
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
        }
        
        private void OnLevelComplete()
        {
            audioSource.PlayOneShot(audioClips[2]);
        }
        private void OnPlayerCollectPoint()
        {
            audioSource.PlayOneShot(audioClips[0]);
        }
        private void OnPlayerCrash()
        {
            audioSource.PlayOneShot(audioClips[1]);
        }
    }   
}