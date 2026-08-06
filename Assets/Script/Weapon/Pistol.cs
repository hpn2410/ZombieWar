using UnityEngine;

public class Pistol : Weapon
{
    public override WeaponType Type => WeaponType.Pistol;

    protected override void Fire()
    {
        Debug.Log("Pistol Fire");
    }
}