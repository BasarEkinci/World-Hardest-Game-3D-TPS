using Runtime.Extentions;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SoundManager : MonoSingelton<SoundManager>
    {
        [SerializeField] private AudioClip[] audioClips;
        private AudioSource[] _audios;
        
        private new void Awake()
        {
            _audios = GetComponentsInChildren<AudioSource>();
        }
        private void Start()
        {
            _audios[0].Play();
        }
        public void PlayGame()
        {
            _audios[0].Stop();
            _audios[1].Play();
        }
        public void RestartGame()
        {
            _audios[1].Stop();
            _audios[0].Play();
        }

        public void PlayEffect(int index)
        {
            _audios[2].PlayOneShot(audioClips[index]);
        }
    }   
}