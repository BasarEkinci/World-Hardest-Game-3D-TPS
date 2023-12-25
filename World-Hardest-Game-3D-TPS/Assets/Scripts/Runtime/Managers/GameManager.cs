using Runtime.Signals;
using Unity.VisualScripting;
using UnityEngine;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject globalVolume;
        
        private Animator _animator;
        private int _startGame = Animator.StringToHash("StartGame");
        private int _restratGame = Animator.StringToHash("RestartGame");

        private void Awake()
        {
            _animator = globalVolume.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }
        private void Start()
        {
            Application.targetFrameRate = 60;
            print(_startGame);
            print(_restratGame);
        }
        private void OnDisable()
        {
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
        }
        private void OnGameStart()
        {
            _animator.SetBool(_startGame,true);
            _animator.SetBool(_restratGame,false);
            print("Game Started");
            print(_startGame);
            print(_restratGame);
        }
        private void OnGameRestart()
        {
            _animator.SetBool(_startGame,false);
            _animator.SetBool(_restratGame,true);
        }
    }
}