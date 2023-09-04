using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _durationShaking = 0.2f;
    [SerializeField] private float _shakingValue = 0.05f;
    private float _initialXValue;
    private float _initialYValue;
    private float _shakeXValue;
    private float _shakeYValue;

    public void Initialization()
    {
        _initialXValue = transform.position.x;
        _initialYValue = transform.position.y;
    }

    private void OnEnable()
    {
        PlayerCube.OnCameraShaken += ShakeCamera;
    }

    private void OnDisable()
    {
        PlayerCube.OnCameraShaken -= ShakeCamera;
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCoroutine(_durationShaking));
    }

    private IEnumerator ShakeCoroutine(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            _shakeXValue = Random.Range((_initialXValue - _shakingValue), (_initialXValue + _shakingValue));
            _shakeYValue = Random.Range((_initialYValue - _shakingValue), (_initialYValue + _shakingValue));

           transform.position = new Vector3(_shakeXValue, _shakeYValue, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = new Vector3(_initialXValue, _initialYValue, transform.position.z);
    }


}
