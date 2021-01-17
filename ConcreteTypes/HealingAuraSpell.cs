using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealingAuraSpell", menuName = "ScriptableObjects/Spells/Aura/Healing", order = 1)]
public class HealingAuraSpell : AuraSpell
{
    public float healPerCast;

    public override void Cast(Transform parent, Vector3 position, Vector3 direction)
    {
        base.Cast(parent, position, direction);
    }

    public override void Apply(Vector3 position)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(position, hitRadius);
        foreach (Collider2D target in collisions)
        {

            if ((targetLayers.value & 1 << target.gameObject.layer) == 1 << target.gameObject.layer)
            {
                target.gameObject.SendMessage("TakeHit", -healPerCast);
            }
        }
        base.Apply(position);
    }

}
