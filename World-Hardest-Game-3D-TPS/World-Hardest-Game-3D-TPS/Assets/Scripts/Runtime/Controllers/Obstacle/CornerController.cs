using UnityEngine;

namespace Runtime.Controllers.Obstacle
{
    public class CornerController : MonoBehaviour
    {
        [SerializeField] private Vector3 moveDirection;
        private void OnTriggerEnter(Collider other)
        {
            BeybladeMovementController beyblade = other.GetComponent<BeybladeMovementController>();
            if (beyblade != null)
            {
                beyblade.MoveDirection = moveDirection;
            }
        }
    }
}