using UnityEngine;

public enum WeaponType
{
    Rifle,
    Pistol
}

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private int currentIndex;

    public Weapon CurrentWeapon => weapons[currentIndex];

    private void Start()
    {
        Equip(currentIndex);
    }

    public Weapon SwitchWeapon()
    {
        currentIndex++;

        if (currentIndex >= weapons.Length)
            currentIndex = 0;

        Equip(currentIndex);

        return CurrentWeapon;
    }

    private void Equip(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == index);
        }

        currentIndex = index;
    }
}