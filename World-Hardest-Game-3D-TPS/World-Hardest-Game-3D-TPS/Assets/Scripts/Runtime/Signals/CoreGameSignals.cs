using Runtime.Extentions;
using UnityEngine.Events;
namespace Runtime.Signals
{
    public class CoreGameSignals : MonoSingelton<CoreGameSignals>
    {
        public UnityAction OnGameRestart = delegate {  };
        public UnityAction OnLevelComplete = delegate {  };
        public UnityAction OnClearActiveLevel = delegate {  };
        public UnityAction OnLoadLevel = delegate {  };
        public UnityAction OnGameStart = delegate {  };
        public UnityAction OnNextLevel = delegate {  }; 
    }
}