using UnityEngine;

/// <summary>
/// Contains all runtime data needed to execute an ability.
/// </summary>
public struct AbilityContext
{
    public GameObject Caster;
    public GameObject Target;
    public Vector3 Position;
    public Vector3 Direction;
}