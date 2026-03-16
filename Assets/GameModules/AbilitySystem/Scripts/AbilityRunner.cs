using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Executes abilities based on player input, managing cooldowns and costs.
/// </summary>
public class AbilityRunner : MonoBehaviour
{
    [SerializeField] private List<Ability> abilities;
    [SerializeField] private float[] cooldownTimers;
    [SerializeField] private int currentMana;
    [SerializeField] private int maxMana = 100;


    private void Start()
    {
        currentMana = maxMana;
        cooldownTimers = new float[abilities.Count];
    }


    private void Update()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            if ((i == 0 && Input.GetKeyDown(KeyCode.Q)) ||
                (i == 1 && Input.GetKeyDown(KeyCode.W)) ||
                (i == 2 && Input.GetKeyDown(KeyCode.E)))
            {
                TryExecuteAbility(i);
            }


            if (cooldownTimers[i] > 0)
                cooldownTimers[i] -= Time.deltaTime;
        }
    }


    private void TryExecuteAbility(int index)
    {
        if (index < 0 || index >= abilities.Count) return;


        Ability ability = abilities[index];
        if (cooldownTimers[index] > 0f) return;
        if (!HasEnoughResources(ability)) return;

        GameObject target = null;

        // Search for a target only if needed
        if (ability.Effect is DamageEffect)
        {
            target = GameObject.FindWithTag("Enemy");
            if (target == null)
            {
                Debug.Log("No target around the player to shoot");
                return;
            }
        }

        AbilityContext ctx = new AbilityContext
        {
            Caster = gameObject,
            Target = target, // Can be set from a targeting system
            Position = transform.position,
            Direction = transform.forward
        };


        ability.Effect.Execute(ctx);
        cooldownTimers[index] = ability.Cooldown;
        SpendResources(ability);
    }


    private bool HasEnoughResources(Ability ability)
    {
        // exemple with "mana"
        return currentMana >= ability.Cost;
    }


    private void SpendResources(Ability ability)
    {
        // exemple with "mana"
        currentMana -= ability.Cost;
        Debug.Log("Mana left: "+ currentMana + " / " + maxMana);
    }
}