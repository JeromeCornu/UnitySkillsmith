using UnityEngine;

/// <summary>
/// Applies damage to the target if it implements IDamageable.
/// </summary>
[CreateAssetMenu(fileName = "DamageEffect", menuName = "Abilities/Effects/Damage")]
public class DamageEffect : AbilityEffect
{
    public int damageAmount;

    public override void Execute(AbilityContext context)
    {
        if (context.Target == null)
        {
            Debug.LogWarning("DamageEffect: No target provided.");
            return;
        }

        if (context.Target.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damageAmount);
            Debug.Log($"Firebolt hit {context.Target.name}, dealt {damageAmount} damage.");
        }
        else
        {
            Debug.LogWarning($"DamageEffect: Target {context.Target.name} is not damageable.");
        }
    }

}