using System.Collections;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject globalVolume;
        
        private Animator _animator;
        private int _startGame = Animator.StringToHash("StartGame");
        private int _restartGame = Animator.StringToHash("RestartGame");
        
        private bool _isGamePaused;

        private void Awake()
        {
            _animator = globalVolume.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isGamePaused)
                {
                    _isGamePaused = false;
                    _animator.SetBool(_startGame,true);
                    _animator.SetBool(_restartGame,false);
                    Time.timeScale = 1;
                }
                else
                {
                    _isGamePaused = true;
                    _animator.SetBool(_startGame,false);
                    _animator.SetBool(_restartGame,true);
                    StartCoroutine(WaitTime(2f));
                    Time.timeScale = 0;
                }
            }
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
        }

        private void OnGameStart()
        {
            _animator.SetBool(_startGame,true);
            _animator.SetBool(_restartGame,false);
        }
        private void OnGameRestart()
        {
            _animator.SetBool(_startGame,false);
            _animator.SetBool(_restartGame,true);
        }

        IEnumerator WaitTime(float waitTime)
        {
            yield return new WaitForSeconds(waitTime * Time.deltaTime);
        }
    }
}