using System.Collections;
using DG.Tweening;
using Runtime.Signals;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject gameCam;
    [SerializeField] private GameObject startCam;

    private Vector3 _startCamLastRotation;
    private Vector3 _startCamFirstRotation;
    private Vector3 _startCamFirstPos;
    private Vector3 _startCamLastPos;

    private WaitForSeconds _waitTime = new WaitForSeconds(1.5f);

    private void Start()
    {
        _startCamLastRotation = new Vector3(45.699f, 0, 0);
        _startCamFirstRotation = new Vector3(20, -20f, 0);
        _startCamFirstPos = new Vector3(-6, 6, -20);
        _startCamLastPos = gameCam.transform.position;
    }

    private void OnEnable()
    {
        CoreGameSignals.Instance.OnGameStart += OnGameStart;
        CoreGameSignals.Instance.OnGameRestart += OnGameRestart;
    }
    
    private void OnDisable()
    {
        CoreGameSignals.Instance.OnGameStart -= OnGameStart;
        CoreGameSignals.Instance.OnGameRestart -= OnGameRestart;
    }
    
    private void OnGameStart()
    {
        StartCoroutine(StartActions());
    }
    
    private void OnGameRestart()
    {
        StartCoroutine(RestartActions());
    }

    private IEnumerator StartActions()
    {
        startCam.transform.DOMove(_startCamLastPos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() => startCam.transform.DORotate(_startCamLastRotation, 1f));
        yield return _waitTime;
        startCam.SetActive(false);
        gameCam.SetActive(true);
    }

    private IEnumerator RestartActions()
    {
        startCam.SetActive(true);
        gameCam.SetActive(false);
        yield return new WaitForSeconds(0);
        startCam.transform.DOMove(_startCamFirstPos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() => startCam.transform.DORotate(_startCamFirstRotation, 1f));
    }
}
