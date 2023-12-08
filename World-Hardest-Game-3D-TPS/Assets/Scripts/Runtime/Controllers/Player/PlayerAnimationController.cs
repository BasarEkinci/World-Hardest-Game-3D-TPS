using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private List<GameObject> wheels;
        internal void SetAnimation()
        {
            if(!Input.anyKey) return;
            float rotateAmount = rotationSpeed * Time.deltaTime;
            foreach (var wheel in wheels)
            {
                wheel.transform.Rotate(0,0,rotateAmount);
            }
        }
    }
}
