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
            Object.Instantiate(Resources.Load<GameObject>($"Prefabs/Levels/Level{levelIndex}"),_levelHolder, true);
        }
    }
}