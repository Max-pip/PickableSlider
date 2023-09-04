using UnityEngine;

public class Wall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(StringConstant.StickmanTag))
        {
            GameManager.Instance.EndGame();
        }
    }
}
