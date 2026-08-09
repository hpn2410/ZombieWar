using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Slider healthBarSlider;

    private float currentHealth;
    private float maxHealth;
    private bool isDead = false;
    private PlayerEffect playerEffect;

    private void Awake()
    {
        playerEffect = GetComponent<PlayerEffect>();
        maxHealth = playerData.health;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            isDead = true;
        }
        
        playerEffect.PlayHitEffect();
        
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        Debug.Log("Player current health: " + currentHealth);
        float value = currentHealth / maxHealth;
        healthBarSlider.value = value;
    }

    private void Die()
    {

    }
}
