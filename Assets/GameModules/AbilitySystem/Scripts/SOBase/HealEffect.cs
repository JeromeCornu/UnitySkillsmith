using UnityEngine;

/// <summary>
/// Heals the caster if it has a HealthComponent.
/// </summary>
[CreateAssetMenu(fileName = "HealEffect", menuName = "Abilities/Effects/Heal")]
public class HealEffect : AbilityEffect
{
    public int healAmount;


    public override void Execute(AbilityContext context)
    {
        if (context.Caster.TryGetComponent(out HealthComponent health))
        {
            health.AddHealth(healAmount);
            Debug.Log($"Healed {healAmount}. Current health: {health.CurrentHealth}");
        }
        else
        {
            Debug.LogWarning("HealEffect: No HealthComponent found on caster.");
        }
    }
}