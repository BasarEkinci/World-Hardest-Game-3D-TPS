using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerSoundController : MonoBehaviour
    {
        [SerializeField] private float minPitch;
        [SerializeField] private float maxPitch;
        
        private AudioSource _playerAudio;
        private Vector3 _previousPosition;
        private Vector3 _currentPosition;
        private float _distance;
        private float _pitchFromPlayer;

        private void Awake()
        {
            _playerAudio = GetComponent<AudioSource>();
        }
        internal void SetSound()
        {
            _pitchFromPlayer = _distance > 0.008f ? maxPitch : minPitch;
            _playerAudio.pitch = _pitchFromPlayer;
        }
        internal void CalculateDistance()
        {
            _currentPosition = transform.position;
            _distance = Vector3.Distance(_previousPosition, _currentPosition);
            _previousPosition = _currentPosition;
        }
    }
}