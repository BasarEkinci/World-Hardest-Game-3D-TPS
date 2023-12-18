using System.Collections;
using DG.Tweening;
using Runtime.Signals;
using UnityEngine;

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
        
        private void OnLevelComplete()
        {
            if(_levelCounter < 4)
                winPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            else
                endGamePanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
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
            endGamePanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).
                OnComplete(RestartActions);
        }
        private void RestartActions()
        {
            startPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).
                OnComplete(RestartSignals);
        }
        private void RestartSignals()
        {
            CoreGameSignals.Instance.OnGameRestart?.Invoke();
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
        }
        public void NextLevel()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLoadLevel?.Invoke();
            CoreGameSignals.Instance.OnNextLevel?.Invoke();
            winPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
            _levelCounter++;
        }


    }
}
