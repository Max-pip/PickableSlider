using System;
using UnityEngine;

public class TriggerSpawnTile : MonoBehaviour
{
    public static Action OnTileSpawned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(StringConstant.PlayerTag))
        {
            OnTileSpawned?.Invoke();
        }
    }
}
