using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseSpeedSpell", menuName = "ScriptableObjects/Spells/Boost/IncreaseSpeed", order = 2)]
public class IncreaseSpeedSpell : BoostSpell
{
    public float speedMultiplier;

    public override void Cast(Transform parent, Vector3 position, Vector3 direction)
    {
        base.Cast(parent, position, direction);
    }

    public override void Apply(Vector3 position)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(position, hitRadius);
        foreach (Collider2D target in collisions)
        {
            WarriorMovement warrior = target.gameObject.GetComponent<WarriorMovement>();
            if (warrior && warrior.IncreaseSpeed(speedMultiplier)){
                    base.Effect(target);
                };
            }
        base.Apply(position);
    }
}
