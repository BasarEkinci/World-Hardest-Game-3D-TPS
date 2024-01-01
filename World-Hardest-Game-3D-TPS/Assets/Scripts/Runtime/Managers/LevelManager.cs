using Runtime.Commands;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform levelHolder;
        
        private OnLevelDestoyerCommand _levelDestroyer;
        private OnLevelLoaderCommand _levelLoader;

        private int _levelIndex = 1;
        
        private void Awake()
        {
            _levelDestroyer = new OnLevelDestoyerCommand(levelHolder);
            _levelLoader = new OnLevelLoaderCommand(levelHolder);
        }
        private void OnEnable()
        {
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
            CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
            CoreGameSignals.Instance.OnGameStart += OnGameStart;
            CoreGameSignals.Instance.OnClearActiveLevel += OnClearActiveLevel;
            CoreGameSignals.Instance.OnLoadLevel += OnLoadLevel;
        }
        private void OnDisable()
        {
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
            CoreGameSignals.Instance.OnGameStart -= OnGameStart;
            CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
            CoreGameSignals.Instance.OnLoadLevel -= OnLoadLevel;
            CoreGameSignals.Instance.OnClearActiveLevel -= OnClearActiveLevel;
        }
        private void OnLoadLevel()
        {
            _levelLoader.Execute(_levelIndex);
        }
        private void OnGameRestart()
        {
            _levelIndex = 1;
        }
        private void OnGameStart()
        {
            _levelLoader.Execute(1);
        }
        private void OnClearActiveLevel()
        {
            _levelDestroyer.Execute();
        }
        private void OnLevelComplete()
        {
            _levelIndex++;
        }
    }
}