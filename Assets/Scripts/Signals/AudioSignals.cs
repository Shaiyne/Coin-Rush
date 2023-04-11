using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioSignals : Singleton<AudioSignals>
{
    public UnityAction onCoinFailedSound = delegate { };
    public UnityAction onCoinSuccessSound = delegate { };
    public UnityAction onClickSound = delegate { };
}
