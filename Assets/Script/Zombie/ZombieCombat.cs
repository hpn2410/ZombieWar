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

        Debug.Log("Zombie Attack");
    }

    public void HitPlayer()
    {
        if(IsPlayerInRange(GameObject.FindGameObjectWithTag("Player").transform))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(zombieData.zombieDamage);
        }
    }
}