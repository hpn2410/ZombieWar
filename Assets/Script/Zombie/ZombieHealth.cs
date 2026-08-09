using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private ZombieData zombieData;
    [SerializeField] private Slider healthBarSlider;

    private float currentHealth;
    private float maxHealth;

    private ZombieAI zombieAI;
    private bool isDead = false;
    private ZombieEffect zombieEffect;

    private void Awake()
    {
        zombieAI = GetComponent<ZombieAI>();
        zombieEffect = GetComponent<ZombieEffect>();
        maxHealth = zombieData.zombieHealth;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if(isDead) 
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            isDead = true;
        }
        zombieEffect.PlayHitEffect();
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        Debug.Log("Zombie current health: " + currentHealth);
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