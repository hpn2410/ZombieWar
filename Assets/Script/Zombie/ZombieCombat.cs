using UnityEngine;

public class ZombieCombat : MonoBehaviour
{
    [SerializeField] private ZombieData zombieData;

    private float nextAttackTime;

    public bool IsPlayerInRange(Transform player)
    {
        return Vector3.Distance(transform.position, player.position) <= zombieData.attackRange;
    }

    public void Attack(Transform player)
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + zombieData.attackCooldown;
    }

    public void HitPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (IsPlayerInRange(player.transform))
        {
            player.GetComponent<PlayerHealth>().TakeDamage(zombieData.zombieDamage);
            player.GetComponent<PlayerEffect>().PlayHitEffect();
        }
    }
}