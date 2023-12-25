using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        
        [SerializeField] private float movementSpeed;
        [SerializeField] private float lookSmooth;
        [SerializeField] private float directionSmooth;
        
        private Vector3 _inputDirection = Vector3.zero;
        private Vector3 _effectiveDirection = Vector3.zero;
        
        internal void Move()
        {
            float movementHorizontal = Input.GetAxisRaw("Horizontal");
            float movementVertical = Input.GetAxisRaw("Vertical");

            _inputDirection.x = movementHorizontal;
            _inputDirection.z = movementVertical;
            _inputDirection.Normalize();

            if (_inputDirection.magnitude > 0.01f)
            {
                float lookAngle = Mathf.Atan2(_inputDirection.x, _inputDirection.z) * Mathf.Rad2Deg;
                float effectiveAngles = Mathf.LerpAngle(transform.rotation.eulerAngles.y, lookAngle, lookSmooth);
                transform.rotation = Quaternion.Euler(0,effectiveAngles,0);
            }

            _effectiveDirection = Vector3.Lerp(_effectiveDirection, _inputDirection, directionSmooth);
            
            transform.position += _effectiveDirection * (movementSpeed * Time.deltaTime);
        }
    }
}
