using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Runtime.Controllers.Obstacle
{
    public class BeybladeMovementController : MonoBehaviour
    {
        [SerializeField] private Transform pathParetnt;
        [SerializeField] private float startDelay;
        private IEnumerator Start()
        {
            Vector3[] pathArray = new Vector3[pathParetnt.childCount + 1];
            for (int i = 0; i < pathArray.Length - 1; i++)
            {
                pathArray[i] = pathParetnt.GetChild(i).position;
            }
            pathArray[^1] = pathArray[0];
            yield return new WaitForSeconds(startDelay);
            transform.DOPath(pathArray, 4f).SetLoops(-1).SetEase(Ease.Linear);
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, 720f * Time.deltaTime);
        }
    }
}