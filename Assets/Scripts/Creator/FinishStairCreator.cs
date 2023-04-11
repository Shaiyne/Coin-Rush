using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStairCreator : MonoBehaviour
{
    [SerializeField] GameObject _finishStairs;
 
    private void Start()
    {
        for (int i = 0; i < SaveGameManager.GetPlaneCounts()+2; i++)
        {
            GameObject finishStairs = Instantiate(_finishStairs);
            finishStairs.transform.parent = this.transform;
            finishStairs.transform.position = this.transform.position + new Vector3(0, 2.5f * (i+1), 5 * (i+1));
        }       
    }
}
