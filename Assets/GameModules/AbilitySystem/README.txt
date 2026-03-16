AbilitySystemShowcase
======================

A modular, scalable and production-ready Ability System for Unity.
Built using ScriptableObjects, clean separation of logic and data, and runtime-safe context.

What it demonstrates:
- Clean architecture: Ability (data) vs Effect (logic) vs Runner (orchestration)
- Runtime-safe context passing (caster, target, direction)
- Cooldown, cost, resource check, and execution pipeline
- Easily extensible for real games (RPG, action, roguelike, etc.)
- Fully testable

---

System Overview:

Ability (ScriptableObject)
- Fields: Name, Cooldown, Cost
- Holds a reference to an AbilityEffect

IAbilityEffect (Interface)
- `Execute(AbilityContext ctx)`
- Allows plug-and-play logic

AbilityEffect (Abstract ScriptableObject)
- Base class for all effects, used in inspector

AbilityContext (struct)
- Runtime info passed to effects:
  - Caster (GameObject)
  - Target (GameObject, optional)
  - Position (Vector3)
  - Direction (Vector3)

Included Effects:
- DamageEffect → Applies damage to a target if it has IDamageable
- HealEffect → Restores health to the caster
- DashEffect → Applies forward dash movement using Rigidbody or interpolation

AbilityRunner (MonoBehaviour)
- Listens to input (default: A = Dash, Z = Firebolt, E = Heal)
- Verifies cooldown and resources
- Builds context and executes effect
- Handles cooldown and debug logging

HealthComponent + IDamageable
- Tracks health, healing, death
- Fires events (OnDamage, OnHeal, OnDeath)
- Used by both player and enemies

---

Setup Instructions:
1. Create a GameObject called "Player"
   - Add: AbilityRunner, HealthComponent, Rigidbody (no gravity)
2. Create 3 ScriptableObjects of type AbilityEffect (Damage, Heal, Dash)
3. Create 3 Abilities and link one effect to each
4. In AbilityRunner, assign the 3 Abilities in the list
5. (Optional) Create a GameObject "Enemy" with HealthComponent + tag "Enemy"
6. Press Play → Press A, Z, E to activate abilities

---

Notes:
- Player starts with 50% health to test healing
- Enemy must have HealthComponent + tag "Enemy" to be damaged
- Cooldowns and mana cost are logged to console
- System ready for future extension: UI, pooling, networked execution, etc.

---