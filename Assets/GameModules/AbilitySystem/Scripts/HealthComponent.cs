using UnityEngine;
using System;

/// <summary>
/// Health system that supports healing, damage and death events.
/// </summary>
public class HealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;
    public int CurrentHealth => _currentHealth;


    public event Action OnDeath;
    public event Action<int> OnDamaged;
    public event Action<int> OnHealed;


    private void Awake()
    {
        _currentHealth = Mathf.FloorToInt(_maxHealth * 0.5f); // Start at 50% health
        Debug.Log($"{gameObject.name} starting health: {_currentHealth}/{_maxHealth}");
    }


    public void AddHealth(int amount)
    {
        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        Debug.Log($"{gameObject.name} healed {amount}. Health now: {_currentHealth}/{_maxHealth}");

        OnHealed?.Invoke(amount);
    }


    public void TakeDamage(int amount)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - amount);
        Debug.Log($"{gameObject.name} took {amount} damage. Health now: {_currentHealth}/{_maxHealth}");

        OnDamaged?.Invoke(amount);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

}