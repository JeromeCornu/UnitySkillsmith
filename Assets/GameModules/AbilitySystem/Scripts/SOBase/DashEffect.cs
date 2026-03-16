using UnityEngine;

/// <summary>
/// Dashes the caster forward using a Rigidbody force.
/// </summary>
[CreateAssetMenu(fileName = "DashEffect", menuName = "Abilities/Effects/Dash")]
public class DashEffect : AbilityEffect
{
    public float Force;


    public override void Execute(AbilityContext context)
    {
        if (context.Caster.TryGetComponent(out Rigidbody rb))
        {
            Debug.Log("Dash activated.");
            rb.AddForce(context.Direction.normalized * Force, ForceMode.VelocityChange);
        }
    }
}