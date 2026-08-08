using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private ZombieData zombieData;
    [SerializeField] private Slider healthBarSlider;

    private float currentHealth;
    private float maxHealth;

    private ZombieAI zombieAI;

    private void Awake()
    {
        zombieAI = GetComponent<ZombieAI>();
        maxHealth = zombieData.zombieHealth;
        currentHealth = maxHealth;
        healthBarSlider.value = currentHealth / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBarSlider.value = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            healthBarSlider.value = 0;
            Die();
        }
    }

    private void Die()
    {
        zombieAI.ChangeState(ZombieState.Dead);
    }

    public void ResetHealth()
    {
        currentHealth = zombieData.zombieHealth;
    }
}