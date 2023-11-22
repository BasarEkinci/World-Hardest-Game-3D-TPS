using DG.Tweening;
using UnityEngine;

namespace Runtime.Controllers.Obstacle
{
    public class BeybladeMovementController : MonoBehaviour
    {
        public Vector3 MoveDirection { get; set; }
        private void Start()
        {
            MoveDirection = Vector3.forward * 5f;
        }

        private void Update()
        {
            transform.position += MoveDirection * Time.deltaTime;
            transform.Rotate(Vector3.up, 720f * Time.deltaTime);
        }
    }
}