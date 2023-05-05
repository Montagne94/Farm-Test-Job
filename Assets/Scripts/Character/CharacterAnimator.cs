using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string IS_RUN = "IsRun";
    private const string PLANT = "Plant";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        _animator.SetBool(IS_RUN, false);
    }

    public void SetRun()
    {
        _animator.SetBool(IS_RUN, true);
    }

    public void SetPlant()
    {
        _animator.SetBool(IS_RUN, false);
        _animator.SetTrigger(PLANT);
    }
}