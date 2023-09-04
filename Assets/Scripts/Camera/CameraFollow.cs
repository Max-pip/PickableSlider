using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _distanceFromObject;

    private void FixedUpdate() 
    {
        Vector3 positionToGo = new Vector3(0, 0, _target.position.z) + _distanceFromObject;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, positionToGo, _smoothSpeed);
        transform.position = smoothPosition;
    }

}
