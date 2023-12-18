using Runtime.Controllers.Player;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerAnimationController playerAnimationController;
        [SerializeField] private Transform checkPoint;

        private bool _canMove;
        private Rigidbody _rigidbody;
        private Collider _collider;
        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
            CoreGameSignals.Instance.OnNextLevel += OnNextLevel;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<CapsuleCollider>();
        }

        private void Update()
        {
            if(!_canMove) return;
            playerMovementController.Move();
            playerAnimationController.SetAnimation();

            if (!Input.anyKey)
                _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
            CoreGameSignals.Instance.OnNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
        }
        
        private void OnGameStart()
        {
            _canMove = true;
            _collider.enabled = true;
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
        }
        private void OnGameRestart()
        {
            transform.position = checkPoint.position;
            _canMove = false;
            _collider.enabled = false;
        }
        private void OnPlayerCrash()
        {
            transform.position = checkPoint.position;
            SoundManager.Instance.PlaySound(1);
        }
    }
}