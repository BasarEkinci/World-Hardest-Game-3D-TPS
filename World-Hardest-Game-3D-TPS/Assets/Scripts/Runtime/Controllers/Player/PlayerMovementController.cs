using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        
        [SerializeField] private float movementSpeed;
        [SerializeField] private float lookSmooth;
        [SerializeField] private float directionSmooth;
        
        private Vector3 _effectiveDirection = Vector3.zero;
        
        internal void Move()
        {
            if (inputManager.InputDirection.magnitude > 0.01f)
            {
                float lookAngle = Mathf.Atan2(inputManager.InputDirection.x, inputManager.InputDirection.z) * Mathf.Rad2Deg;
                float effectiveAngles = Mathf.LerpAngle(transform.rotation.eulerAngles.y, lookAngle, lookSmooth);
                transform.rotation = Quaternion.Euler(0,effectiveAngles,0);
            }

            _effectiveDirection = Vector3.Lerp(_effectiveDirection, inputManager.InputDirection, directionSmooth);
            transform.position += _effectiveDirection * (movementSpeed * Time.deltaTime);
        }
    }
}
