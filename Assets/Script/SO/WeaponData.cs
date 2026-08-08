using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public WeaponType type;

    [Header("Weapon")]
    public float fireRate;

    [Header("Bullet")]
    public int damage;
    public float bulletSpeed;
    public float bulletLifeTime;
}
