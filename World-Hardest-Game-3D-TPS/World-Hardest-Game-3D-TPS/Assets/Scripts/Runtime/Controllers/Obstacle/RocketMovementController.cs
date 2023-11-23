using DG.Tweening;
using UnityEngine;

namespace Runtime.Controllers.Obstacle
{
    public class RocketMovementController : MonoBehaviour
    {
        [SerializeField] private float moveDuration;
        private void Start()
        {
            transform.DORotate(Vector3.up * 360f, moveDuration, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
        }
    }
}