using UnityEngine;
using Object = UnityEngine.Object;

namespace Runtime.Commands
{
    public class OnLevelDestoyerCommand
    {
        private Transform levelHolder;

        internal OnLevelDestoyerCommand(Transform levelHolder)
        {
            this.levelHolder = levelHolder;
        }
        internal void Execute()
        {
            if(levelHolder.transform.childCount <= 0 ) return;
            Object.Destroy(levelHolder.transform.GetChild(0).gameObject);
        }
    }
}