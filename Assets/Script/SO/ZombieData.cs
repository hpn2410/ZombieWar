using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Scriptable Objects/ZombieData")]
public class ZombieData : ScriptableObject
{
    public float zombieHealth;
    public int zombieDamage;
    public float attackRange;
    public float attackCooldown;
}
