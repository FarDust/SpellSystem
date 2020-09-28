using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireballSpell", menuName = "ScriptableObjects/Spells/Damage/Fireball", order = 1)]
public class FireballSpell : DamageSpell
{
    public override void Cast(Transform parent, Vector3 position, Vector3 direction)
    {
        base.Cast(parent, position, direction);
    }
}
