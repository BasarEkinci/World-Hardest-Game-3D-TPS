using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerSoundController : MonoBehaviour
    {
        [SerializeField] private float minPitch;
        [SerializeField] private float maxPitch;
        
        private AudioSource _playerAudio;
        private Vector3 _previousPosition;
        
        private float _pitchFromPlayer;

        private void Awake()
        {
            _playerAudio = GetComponent<AudioSource>();
        }
        internal void PlaySound()
        {
            var currentPosition = transform.position;
            
            var distance = Vector3.Distance(_previousPosition, currentPosition);

            _pitchFromPlayer = distance > 0.008f ? maxPitch : minPitch;
            _playerAudio.pitch = _pitchFromPlayer;
            _previousPosition = currentPosition;
            Debug.Log(distance);
        }
    }
}