using UnityEngine;

public class PlayerAnimationHandle : MonoBehaviour
{
    Animator playerAnimator;

    public static PlayerAnimationHandle Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void PlayerRun()
    {
        playerAnimator.SetBool("IsRun", true);
    }

    public void PlayerIdle()
    {
        playerAnimator.SetBool("IsRun", false);
    }

    public void ActiveRifeFire()
    {
        int layerIndex = playerAnimator.GetLayerIndex("RifleFiring");
        playerAnimator.SetLayerWeight(1, 1f);
    }

    public void DeactivateRifeFire()
    {
        int layerIndex = playerAnimator.GetLayerIndex("RifleFiring");
        playerAnimator.SetLayerWeight(1, 0f);
    }
}
