using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSignals : Singleton<PlayerSignals>
{
    public UnityAction onGameStart = delegate { };
    public UnityAction<Transform> onCollectibleCoinContact = delegate { };
    public UnityAction onFinishArch = delegate { };
    public UnityAction onFinishStair = delegate { };
}
