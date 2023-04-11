using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    protected void ClickSound()
    {
        AudioSignals.Instance.onClickSound?.Invoke();
    }
    protected void CloseGameButton()
    {
        CoreSignals.Instance.onCloseGame?.Invoke();
        ClickSound();
    }
}
