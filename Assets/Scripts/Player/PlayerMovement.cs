using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardValue = 5f;
    [SerializeField] private float _sidewaysValue = 0;
    [SerializeField] private float _sidewaysSpeed;
    [SerializeField] private float _limitX = 2f;

    private void FixedUpdate()
    {
        if (!GameManager.Instance.isGameRun)
        {
            return;
        }

        PlayerMove();
    }

    private void PlayerMove()
    {
        float vectorValueX;
        float vectorValueZ;

        vectorValueX = transform.position.x + _sidewaysSpeed * _sidewaysValue * Time.deltaTime;
        vectorValueX = Mathf.Clamp(vectorValueX, -_limitX, _limitX);
        vectorValueZ = transform.position.z + _forwardValue * Time.deltaTime;

        Vector3 newPosition = new Vector3(vectorValueX, transform.position.y, vectorValueZ);
        transform.position = newPosition;
    }

    public void SetSidewaysValue(float sidewaysValue)
    {
        _sidewaysValue = sidewaysValue;
    }
}
