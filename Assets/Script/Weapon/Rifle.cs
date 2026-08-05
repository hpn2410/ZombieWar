using UnityEngine;

public class Rifle : Weapon
{
    protected override void Fire()
    {
        Debug.Log("fire");
    }

    public override void SetFireAnimation(bool active)
    {
        if (PlayerAnimationHandle.Instance == null)
            return;

        PlayerAnimationHandle.Instance.SetRifleFireLayer(active);
    }
}
