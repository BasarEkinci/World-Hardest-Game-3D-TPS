using System;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        private Animator _animator;
        private int _startGame = Animator.StringToHash("StartGame");
        private int _restratGame = Animator.StringToHash("RestartGame");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
        }
        private void Start()
        {
            Application.targetFrameRate = 60;
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
        }
        private void OnGameRestart()
        {
            _animator.SetBool(_startGame,false);
            _animator.SetBool(_restratGame,true);
        }
    }
}