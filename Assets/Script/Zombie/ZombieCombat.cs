using UnityEngine;

public class ZombieCombat : MonoBehaviour
{
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float attackCooldown = 1f;

    private float nextAttackTime;

    public bool IsPlayerInRange(Transform player)
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    public void Attack(Transform player)
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackCooldown;

        Debug.Log("Zombie Attack");

        // player.GetComponent<PlayerHealth>().TakeDamage(...);
    }
}