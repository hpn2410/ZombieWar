using UnityEngine;

public class ZombieAnimationHandle : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayWalk()
    {
        animator.SetBool("IsAttack", false);
    }

    public void PlayAttack()
    {
        animator.SetBool("IsAttack", true);
    }

    public void PlayDead()
    {
        animator.SetTrigger("Die");
    }

    public void ResetAnimation()
    {
        animator.SetBool("IsAttack", false);
    }
}
