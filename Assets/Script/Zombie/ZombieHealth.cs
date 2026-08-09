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
            //healthBarSlider.value = 0;
            Die();
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBarSlider.value = currentHealth / maxHealth;
    }

    private void Die()
    {
        zombieAI.ChangeState(ZombieState.Dead);
    }

    public void ResetHealth()
    {
        currentHealth = zombieData.zombieHealth;
        UpdateHealthBar();
    }
}