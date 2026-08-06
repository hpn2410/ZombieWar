using UnityEngine;

public class PlayerAnimationHandle : MonoBehaviour
{
    public static PlayerAnimationHandle Instance { get; private set; }

    private Animator playerAnimator;

    private int rifleFiringLayer;
    private int pistolFiringLayer;

    private const string IsRun = "IsRun";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        playerAnimator = GetComponent<Animator>();

        if (playerAnimator == null)
        {
            Debug.LogError("PlayerAnimationHandle: Animator not found!");
            return;
        }

        rifleFiringLayer = playerAnimator.GetLayerIndex("RifleFiring");
        pistolFiringLayer = playerAnimator.GetLayerIndex("PistolFiring");

        if (rifleFiringLayer == -1)
        {
            Debug.LogError("PlayerAnimationHandle: RifleFiring layer not found!");
        }

        if (pistolFiringLayer == -1)
        {
            Debug.LogError("PlayerAnimationHandle: PistolFiring layer not found!");
        }
    }

    public void PlayerRun()
    {
        if (playerAnimator == null)
            return;

        playerAnimator.SetBool(IsRun, true);
    }

    public void PlayerIdle()
    {
        if (playerAnimator == null)
            return;

        playerAnimator.SetBool(IsRun, false);
    }

    //public void ActiveRifleFire()
    //{
    //    if (playerAnimator == null || rifleFiringLayer == -1)
    //        return;

    //    playerAnimator.SetLayerWeight(rifleFiringLayer, 1f);
    //}

    //public void DeactivateRifleFire()
    //{
    //    if (playerAnimator == null || rifleFiringLayer == -1)
    //        return;

    //    playerAnimator.SetLayerWeight(rifleFiringLayer, 0f);
    //}

    //public void ActivePistolFire()
    //{
    //    if (playerAnimator == null || pistolFiringLayer == -1)
    //        return;

    //    playerAnimator.SetLayerWeight(pistolFiringLayer, 1f);
    //}

    //public void DeactivatePistolFire()
    //{
    //    if (playerAnimator == null || pistolFiringLayer == -1)
    //        return;

    //    playerAnimator.SetLayerWeight(pistolFiringLayer, 0f);
    //}

    public void SetRifleFireLayer(bool active)
    {
        if (playerAnimator == null || rifleFiringLayer == -1)
            return;

        playerAnimator.SetLayerWeight(
            rifleFiringLayer,
            active ? 1f : 0f
        );
    }

    public void SetPistolFireLayer(bool active)
    {
        if (playerAnimator == null || pistolFiringLayer == -1)
            return;

        playerAnimator.SetLayerWeight(
            pistolFiringLayer,
            active ? 1f : 0f
        );
    }

    public void SetFireLayer(WeaponType type, bool active)
    {
        SetRifleFireLayer(false);
        SetPistolFireLayer(false);

        switch (type)
        {
            case WeaponType.Rifle:
                SetRifleFireLayer(active);
                break;

            case WeaponType.Pistol:
                SetPistolFireLayer(active);
                break;
        }
    }
}
