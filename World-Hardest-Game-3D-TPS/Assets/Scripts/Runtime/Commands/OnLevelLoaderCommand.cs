using UnityEngine;

namespace Runtime.Commands
{
    public class OnLevelLoaderCommand
    {
        private Transform _levelHolder;
        
        internal OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        internal void Execute(int levelIndex)
        {
            if(Resources.Load<GameObject>($"Prefabs/Levels/Level{levelIndex}") != null)
            {
                if(_levelHolder.childCount > 0) return;
                Object.Instantiate(Resources.Load<GameObject>($"Prefabs/Levels/Level{levelIndex}"), _levelHolder, true);
            }
        }
    }
}