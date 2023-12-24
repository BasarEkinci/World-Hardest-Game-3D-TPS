using System.Collections;
using DG.Tweening;
using Runtime.Signals;
using TMPro;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {   
        [Header("Buttons")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject endGamePanel;

        [Header("Texts")] 
        [SerializeField] private TMP_Text levelText;
        
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
            winPanel.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear);
            endGamePanel.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear);
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

            levelText.text = "Level " + _levelCounter + "\nCompleted";
        }
        public void StartGame()
        {
            CoreGameSignals.Instance.OnGameStart?.Invoke();
            startPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
        }
        public void MainMenu()
        {
            CoreGameSignals.Instance.OnGameRestart?.Invoke();
            _levelCounter = 1;
            _crushCounter = 0;
            endGamePanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).
                OnComplete(() => StartCoroutine(RestartActions()));
        }
        public void NextLevel()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLoadLevel?.Invoke();
            CoreGameSignals.Instance.OnNextLevel?.Invoke();
            winPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
            _levelCounter++;
        }
        private IEnumerator RestartActions()
        {
            CoreGameSignals.Instance.OnGameRestart?.Invoke();
            yield return new WaitForSeconds(1.5f);
            startPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).
                OnComplete(() => CoreGameSignals.Instance.OnClearActiveLevel?.Invoke());
        }
    }
}
