using System;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    public static Action OnCameraShaken;
    private PlayerController _playerController;

    public void Initialization()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(StringConstant.WallTag))
        {
            OnCameraShaken?.Invoke();
            _playerController.HitWall(gameObject);
        }
    }
}
