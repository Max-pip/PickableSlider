using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public void Initialization()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        PlayerEditorInput();
#endif

#if UNITY_ANDROID
        PlayerMobileInput();
#endif

    }

    #region InputMethods
    private void PlayerEditorInput()
    {
        if (Input.GetMouseButton(0)) 
        {
            float sidewaysValue = Input.GetAxis(StringConstant.MouseXValueConst);
            _playerMovement.SetSidewaysValue(sidewaysValue);
        } else
        {
            _playerMovement.SetSidewaysValue(0f);
        }
    }

    private void PlayerMobileInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float sidewaysValue = Input.GetTouch(0).deltaPosition.x;
            _playerMovement.SetSidewaysValue(sidewaysValue);
        } else
        {
            _playerMovement.SetSidewaysValue(0f);
        }
    }
    #endregion
}
