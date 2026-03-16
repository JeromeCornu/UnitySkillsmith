using UnityEngine;

/// <summary>
/// Base ScriptableObject wrapper for IAbilityEffect, allows referencing in Ability.
/// </summary>
public abstract class AbilityEffect : ScriptableObject, IAbilityEffect
{
    public abstract void Execute(AbilityContext context);
}