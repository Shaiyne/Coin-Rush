using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStageCreator : MonoBehaviour
{
    [SerializeField] GameObject _finishArch;
    [SerializeField] GameObject _finishStairs;

    private void OnEnable()
    {
        CoreSignals.Instance.onLevelStart += OnCreateFinishStage;
    }
    private void OnDisable()
    {
        CoreSignals.Instance.onLevelStart -= OnCreateFinishStage;
    }

    private void OnCreateFinishStage()
    {
        Instantiate(_finishArch,transform.parent).transform.localPosition = this.transform.position+new Vector3(0,0,SaveGameManager.GetFinalArcPosZ());
        Instantiate(_finishStairs, transform.parent).transform.localPosition = this.transform.position + new Vector3(0, 0, SaveGameManager.GetPlanePosZLenght());
    }
}
