using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string JumpTriggerName = "Jump";

    public void JumpAnimation()
    {
        _animator.SetTrigger(JumpTriggerName);
    }
}
