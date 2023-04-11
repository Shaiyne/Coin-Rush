using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectibleCoinTag"))
        {
            Destroy(other.gameObject);
            PlayerSignals.Instance.onCollectibleCoinContact?.Invoke(this.transform);
        }
        if (other.gameObject.CompareTag("FinishTag"))
        {
            PlayerSignals.Instance.onFinishArch?.Invoke();
        }
    }

}
