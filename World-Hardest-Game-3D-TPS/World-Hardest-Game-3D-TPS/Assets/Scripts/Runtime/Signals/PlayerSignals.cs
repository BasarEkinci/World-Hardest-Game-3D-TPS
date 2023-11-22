using Runtime.Extentions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class PlayerSignals : MonoSingelton<PlayerSignals>
    {
        public UnityAction OnPlayerCrash = delegate {  };
        public UnityAction OnPlayerCollectPoint = delegate {  };
    }
}
