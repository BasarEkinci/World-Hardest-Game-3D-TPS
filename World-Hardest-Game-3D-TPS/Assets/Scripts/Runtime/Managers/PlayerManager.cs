using Runtime.Controllers.Player;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("Player Controllers")]
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerAnimationController playerAnimationController;
        [SerializeField] private PlayerSoundController playerSoundController;
        
        [Header("Player Objects")]
        [SerializeField] private Transform checkPoint;
        [SerializeField] private ParticleSystem crushParticle;
        [SerializeField] private ParticleSystem finishParticle;

        private bool _canMove;
        private Collider _collider;
        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
            CoreGameSignals.Instance.OnNextLevel += OnNextLevel;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
            CoreGameSignals.Instance.OnResetLevel += OnResetLevel;
            CoreGameSignals.Instance.OnGamePause += OnGamePause;
            CoreGameSignals.Instance.OnGameResume += OnGameResume;
        }

        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
        }
        private void Update()
        {
            if(!_canMove) return;
            playerMovementController.Move();
            playerAnimationController.SetAnimation();
            playerSoundController.PlaySound();
        }
        
        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
            CoreGameSignals.Instance.OnNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
            CoreGameSignals.Instance.OnResetLevel -= OnResetLevel;
            CoreGameSignals.Instance.OnGamePause -= OnGamePause;
            CoreGameSignals.Instance.OnGameResume -= OnGameResume;
        }
        private void OnGameResume()
        {
            _canMove = true;
        }
        private void OnGamePause()
        {
            _canMove = false;
        }
        private void OnResetLevel()
        {
            transform.position = checkPoint.position;
        }

        private void OnGameStart()
        {
            _canMove = true;
            _collider.enabled = true;
            transform.position = checkPoint.position;
        }
        private void OnNextLevel()
        {
            _canMove = true;
            _collider.enabled = true;
            transform.position = checkPoint.position;
        }
        private void OnLevelComplete()
        {
            _canMove = false;
            _collider.enabled = false;
            Instantiate(finishParticle, transform.position, Quaternion.identity);
        }
        private void OnGameRestart()
        {
            _collider.enabled = true;
            transform.position = checkPoint.position;
            _canMove = false;
        }
        private void OnPlayerCrash()
        {
            Instantiate(crushParticle, transform.position, Quaternion.identity);
            transform.position = checkPoint.position;
        }
    }
}