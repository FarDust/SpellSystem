﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldAuraSpell", menuName = "ScriptableObjects/Spells/Aura/Shield", order = 1)]
public class ShieldSpell : AuraSpell
{
    public override void Cast(Transform parent, Vector3 position, Vector3 direction)
    {
        base.Cast(parent, position, direction);
    }

    public override void Apply(Vector3 position)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(position, hitRadius);
        Collider2D playerCollsion = Physics2D.OverlapCircleAll(position, 0.1f)[0];
        foreach (Collider2D target in collisions)
        {

            if ((targetLayers.value & 1 << target.gameObject.layer) == 1 << target.gameObject.layer)
            {
                
            }
        }
        base.Apply(position);
    }
}
