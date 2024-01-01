using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject globalVolume;
        
        private Animator _animator;
        private int _startGame;
        private int _restartGame;
        
        private bool _isGamePaused;
        private bool _isGameStarted;

        private void Awake()
        { 
            _startGame = Animator.StringToHash("StartGame");
            _restartGame = Animator.StringToHash("RestartGame");
            _animator = globalVolume.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
            CoreGameSignals.Instance.OnGamePause += OnGamePause;
            CoreGameSignals.Instance.OnGameResume += OnGameResume;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _isGameStarted)
            {
                if (_isGamePaused)
                {
                    CoreGameSignals.Instance.OnGameResume?.Invoke();

                }
                else
                {
                    CoreGameSignals.Instance.OnGamePause?.Invoke();
                }
            }
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
            CoreGameSignals.Instance.OnGamePause -= OnGamePause;
            CoreGameSignals.Instance.OnGameResume -= OnGameResume;
        }

        private void OnGameResume()
        {
            _isGamePaused = false;
            _animator.SetBool(_startGame,true);
            _animator.SetBool(_restartGame,false);
        }

        private void OnGamePause()
        {
            _isGamePaused = true;
            _animator.SetBool(_startGame,false);
            _animator.SetBool(_restartGame,true);
        }

        private void OnGameStart()
        {
            _isGameStarted = true;
            _animator.SetBool(_startGame,true);
            _animator.SetBool(_restartGame,false);
        }
        private void OnGameRestart()
        {
            _isGameStarted = false;
            _animator.SetBool(_startGame,false);
            _animator.SetBool(_restartGame,true);
        }
    }
}