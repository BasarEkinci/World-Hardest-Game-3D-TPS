using System;
using DG.Tweening;
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

        private void Start()
        {
            transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
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