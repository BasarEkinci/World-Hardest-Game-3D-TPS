using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Level
{
    public class FinishAreaController : MonoBehaviour
    {
        [SerializeField] private int requiredObjectCount;
        private int _currentObjectCount;

        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint += OnPlayerCollectPoint;
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
            PlayerSignals.Instance.OnPlayerCollectPoint -= OnPlayerCollectPoint;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && _currentObjectCount == requiredObjectCount)
            {
                CoreGameSignals.Instance.OnLevelComplete?.Invoke();
                Debug.Log("Level Complete");
            }
        }

        private void OnPlayerCollectPoint()
        {
            _currentObjectCount++;
        }

        private void OnPlayerCrash()
        {
            _currentObjectCount = 0;
        }
    }
}
