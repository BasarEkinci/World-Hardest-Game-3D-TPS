using UnityEngine;

namespace Runtime.Managers
{
    public class InputManager : MonoBehaviour
    {
        public Vector3 InputDirection => _inputDirection;
        
        private Vector3 _inputDirection = Vector3.zero;
        
        private void Update()
        {
            float movementHorizontal = Input.GetAxisRaw("Horizontal");
            float movementVertical = Input.GetAxisRaw("Vertical");

            _inputDirection.x = movementHorizontal;
            _inputDirection.z = movementVertical;
            _inputDirection.Normalize();
        }
    }
}