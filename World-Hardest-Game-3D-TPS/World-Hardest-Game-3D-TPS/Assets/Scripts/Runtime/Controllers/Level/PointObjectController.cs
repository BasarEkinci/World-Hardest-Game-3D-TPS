using System;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Level
{
    public class PointObjectController : MonoBehaviour
    {
        [SerializeField] GameObject pointObject;
        private void OnEnable()
        {
            PlayerSignals.Instance.OnPlayerCrash += OnPlayerCrash;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<Collider>().enabled = false;
                PlayerSignals.Instance.OnPlayerCollectPoint?.Invoke();
                pointObject.SetActive(false);
            }
        }           
        
        private void OnDisable()
        {
            PlayerSignals.Instance.OnPlayerCrash -= OnPlayerCrash;
        }
        private void OnPlayerCrash()
        {
            pointObject.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}