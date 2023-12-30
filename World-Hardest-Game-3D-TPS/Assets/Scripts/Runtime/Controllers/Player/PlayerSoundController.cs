using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerSoundController : MonoBehaviour
    {
        
        [SerializeField] private float minPitch;
        [SerializeField] private float maxPitch;
        
        private AudioSource _playerAudio;
        
        private float _pitchFromPlayer;

        private void Awake()
        {
            _playerAudio = GetComponent<AudioSource>();
        }

        private void Update()
        {
            PlayerSound();
        }

        private void PlayerSound()
        {
            if(Input.anyKey && !Input.GetMouseButton(0))
                _playerAudio.pitch = maxPitch;
            else 
                _playerAudio.pitch = minPitch;
        }
    }
}