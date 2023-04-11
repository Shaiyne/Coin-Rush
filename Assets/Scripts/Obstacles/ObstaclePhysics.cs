using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePhysics : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoreSignals.Instance.onLevelFailed?.Invoke();
        }
    }
}
