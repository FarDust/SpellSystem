﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseJumpSpell", menuName = "ScriptableObjects/Spells/Boost/IncreaseJump", order = 1)]
public class IncreaseJumpSpell : BoostSpell
{
    public float jumpMultiplier;

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
                target.gameObject.SendMessage("IncreaseJump", jumpMultiplier);
                //base.Effect(target);
            }
        }
        base.Apply(position);
    }

}
