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
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float value = currentHealth / maxHealth;
            
        healthBarSlider.value = value;
    }

    private void Die()
    {

    }
}
