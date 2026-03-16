/// <summary>
/// Interface for all ability effects.
/// Allows pluggable behaviors.
/// </summary>
public interface IAbilityEffect
{
    void Execute(AbilityContext context);
}