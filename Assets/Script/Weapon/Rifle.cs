using UnityEngine;

public class Rifle : Weapon
{
    public override WeaponType Type => WeaponType.Rifle;

    protected override void Fire()
    {
        Debug.Log("Rifle Fire");
    }
}