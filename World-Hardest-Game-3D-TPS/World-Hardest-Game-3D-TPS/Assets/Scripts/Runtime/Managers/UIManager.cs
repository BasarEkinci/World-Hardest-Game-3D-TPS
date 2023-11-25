using System;
using DG.Tweening;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject endGamePanel;

        private int _crushCounter;
        private int _levelCounter;
        private void OnEnable()
        {
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
        }

        private void Start()
        {
            _crushCounter = 0;
            _levelCounter = 1;
            startPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
        }

        private void OnPlayerCrash()
        {
            _crushCounter++;
        }
        
        public void StartGame()
        {
            CoreGameSignals.Instance.OnGameStart?.Invoke();
            startPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
        }
        public void MainMenu()
        {
            _levelCounter = 1;
            _crushCounter = 0;
            SceneManager.LoadScene(0);
        }
        public void NextLevel()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLoadLevel?.Invoke();
            CoreGameSignals.Instance.OnNextLevel?.Invoke();
            winPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
            _levelCounter++;
        }

        private void OnLevelComplete()
        {
            if(_levelCounter < 4)
                winPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            else
                endGamePanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }
    }
}
