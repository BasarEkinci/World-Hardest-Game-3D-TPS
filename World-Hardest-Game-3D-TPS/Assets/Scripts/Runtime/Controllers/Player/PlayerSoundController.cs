using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerSoundController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        
        [Header("Audio Settings")]
        [SerializeField] private float minPitch;
        [SerializeField] private float maxPitch;
        private AudioSource _playerAudio;
        private float _pitchFromPlayer;
        
        private Vector3 _previousPosition;
        private Vector3 _currentPosition;
        private float _distance;

        private void Awake()
        {
            _playerAudio = GetComponent<AudioSource>();
        }
        internal void SetSound()
        {
            _playerAudio.pitch = inputManager.InputDirection.magnitude > 0.01f ? maxPitch : minPitch;
        }
    }
}