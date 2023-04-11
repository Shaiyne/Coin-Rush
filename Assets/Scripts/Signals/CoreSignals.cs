using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreSignals : Singleton<CoreSignals>
{
   public UnityAction onLevelStart = delegate { };
   public UnityAction onLevelSucceded = delegate { };
   public UnityAction onLevelFailed = delegate { };
   public UnityAction onNextLevel = delegate { };
   public UnityAction onCloseGame = delegate { };
   public UnityAction onRestartLevel = delegate { };
   public UnityAction onStartGame = delegate { };
}
