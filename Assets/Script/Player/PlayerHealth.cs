using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Slider healthBarSlider;

    private float currentHealth;
    private float maxHealth;

    private void Awake()
    {
        maxHealth = playerData.health;
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
        // game over
    }
}
