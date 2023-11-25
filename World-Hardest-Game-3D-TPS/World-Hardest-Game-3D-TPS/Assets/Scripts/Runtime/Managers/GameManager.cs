using UnityEngine;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 60;
        }
    }
}