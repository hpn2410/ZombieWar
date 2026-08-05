using UnityEngine;

public class Pistol : Weapon
{
    protected override void Fire()
    {
        Debug.Log("Pistol fire");
    }

    public override void SetFireAnimation(bool active)
    {
        PlayerAnimationHandle.Instance.SetPistolFireLayer(active);
    }
}