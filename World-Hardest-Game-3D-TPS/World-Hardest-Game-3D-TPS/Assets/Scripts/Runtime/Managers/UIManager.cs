using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            CoreGameSignals.Instance.OnLevelComplete += OnLevelComplete;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnLevelComplete -= OnLevelComplete;
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLoadLevel?.Invoke();
            CoreGameSignals.Instance.OnNextLevel?.Invoke();
        }

        private void OnLevelComplete()
        {
            Debug.Log("Level Complete");
        }
    }
}
