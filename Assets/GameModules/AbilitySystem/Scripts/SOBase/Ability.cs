using UnityEngine;

/// <summary>
/// Represents the data structure for an ability, fully driven by ScriptableObject.
/// No logic inside, only parameters.
/// </summary>
[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/Ability")]
public class Ability : ScriptableObject
{
    public string AbilityName;
    public float Cooldown;
    public int Cost;
    public AbilityEffect Effect; // ScriptableObject referencing a concrete IAbilityEffect
}