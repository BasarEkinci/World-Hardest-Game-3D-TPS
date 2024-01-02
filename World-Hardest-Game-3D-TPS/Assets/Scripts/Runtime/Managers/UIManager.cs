using System.Collections;
using DG.Tweening;
using Runtime.Signals;
using TMPro;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {   
        [Header("Panels")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private GameObject pausePanel;

        [Header("Texts")] 
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text levelTextInGame;
        [SerializeField] private TMP_Text crushCountText;
        
        private int _crushCounter;
        private int _levelCounter;
        
        
        private void OnEnable()
        {
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
            CoreGameSignals.Instance.OnGamePause += OnGamePause;
            CoreGameSignals.Instance.OnGameResume += OnGameResume;
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
        }

        private void Start()
        {
            gamePanel.SetActive(false);
            _crushCounter = 0;
            _levelCounter = 1;
            crushCountText.text = "Crush Count: " + _crushCounter;
            levelTextInGame.text = "Level: " + _levelCounter;
            startPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            winPanel.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear);
            endGamePanel.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear);
        }
        private void OnDisable()
        {
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
            CoreGameSignals.Instance.OnGamePause -= OnGamePause;
            CoreGameSignals.Instance.OnGameResume -= OnGameResume;
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
        }

        private void OnGameResume()
        {
            pausePanel.transform.DOScale(Vector3.zero,0.2f).SetEase(Ease.InBack);
        }

        private void OnGamePause()
        {
            pausePanel.transform.DOScale(Vector3.one,0.2f).SetEase(Ease.OutBack);
        }

        private void OnPlayerCrash()
        {
            _crushCounter++;
            crushCountText.text = "Crush Count: " + _crushCounter;
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
            UISignals.Instance.OnButtonCliceked?.Invoke();
            CoreGameSignals.Instance.OnGameStart?.Invoke();
            gamePanel.SetActive(true);
            startPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
        }
        public void MainMenu()
        {
            pausePanel.transform.DOScale(Vector3.zero,0.2f).SetEase(Ease.InBack);
            _levelCounter = 1;
            _crushCounter = 0;
            levelTextInGame.text = "Level: " + _levelCounter;
            crushCountText.text = "Crush Count: " + _crushCounter;
            UISignals.Instance.OnButtonCliceked?.Invoke();
            CoreGameSignals.Instance.OnGameRestart?.Invoke();
            gamePanel.SetActive(false);
            endGamePanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).
                OnComplete(() => StartCoroutine(RestartActions()));
        }
        
        public void SourceButton(string url)
        {
            Application.OpenURL(url);
            UISignals.Instance.OnButtonCliceked?.Invoke();
        }
        
        public void NextLevel()
        {
            UISignals.Instance.OnButtonCliceked?.Invoke();
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLoadLevel?.Invoke();
            CoreGameSignals.Instance.OnNextLevel?.Invoke();
            winPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
            _levelCounter++;
            levelTextInGame.text = "Level: " + _levelCounter;
        }

        public void ResumeGameButton()
        {
            CoreGameSignals.Instance.OnGameResume?.Invoke();
            UISignals.Instance.OnButtonCliceked?.Invoke();
        }
        public void ResetLevelButton()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLoadLevel?.Invoke();
            CoreGameSignals.Instance.OnGameResume?.Invoke();
            CoreGameSignals.Instance.OnResetLevel?.Invoke();
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
