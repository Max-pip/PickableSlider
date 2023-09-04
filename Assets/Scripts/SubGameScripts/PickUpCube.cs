using System;
using UnityEngine;

public class PickUpCube : MonoBehaviour
{
    public static Action OnCubesPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(StringConstant.PlayerCubeTag))
        {
            OnCubesPickUp?.Invoke();
            Destroy(gameObject);
        }
    }
}
