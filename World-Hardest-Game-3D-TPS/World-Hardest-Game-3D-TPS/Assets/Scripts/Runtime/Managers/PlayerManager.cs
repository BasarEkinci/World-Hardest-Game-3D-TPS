using System.Collections;
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

        private bool _canMove = true;
        
        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
            CoreGameSignals.Instance.OnNextLevel += OnNextLevel;
            
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
            CoreGameSignals.Instance.OnNextLevel -= OnNextLevel;
        }

        private void OnNextLevel()
        {
            _canMove = true;
            transform.position = checkPoint.position;
        }

        private void OnLevelComplete()
        {
            StartCoroutine(WinCoolDown());
        }
        IEnumerator WinCoolDown()
        {
            yield return new WaitForSeconds(1f);
            _canMove = false;
        }
        private void OnPlayerCrash()
        {
            transform.position = checkPoint.position;
        }

        private void Update()
        {
            if(!_canMove) return;
            playerMovementController.Move();
            playerAnimationController.SetAnimation();
        }
    }
}