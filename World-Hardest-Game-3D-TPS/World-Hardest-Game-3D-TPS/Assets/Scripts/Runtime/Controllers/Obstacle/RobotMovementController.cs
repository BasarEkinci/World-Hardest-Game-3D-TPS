using DG.Tweening;
using UnityEngine;

namespace Runtime.Controllers.Obstacle
{
    public class RobotMovementControllers : MonoBehaviour
    {
        [SerializeField] private Vector3 endPos;
        [SerializeField] private float duration;

        private void Start()
        {
            transform.DOMove(endPos, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}