using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                PlayerSignals.Instance.OnPlayerCrash?.Invoke();
            }
        }
    }
}