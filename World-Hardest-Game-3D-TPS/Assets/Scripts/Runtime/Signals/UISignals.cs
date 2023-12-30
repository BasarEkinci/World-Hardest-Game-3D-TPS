using Runtime.Extentions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class UISignals : MonoSingelton<UISignals>
    {
        public UnityAction OnButtonCliceked = delegate {  };
    }
}