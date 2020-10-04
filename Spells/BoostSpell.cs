﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpell : BaseSpell
{
    public AudioClip onCreateSound;
    public AudioClip onCastingSound;
    public AudioClip onCancelSound;

    public LayerMask targetLayers;
    public float hitRadius;
    public float effectRadius;
    public float castPeriod;
    public float duration;
    public GameObject spellPrefab;

    public override void Cast(Transform parent, Vector3 position, Vector3 direction)
    {
        GameObject spell = Instantiate(spellPrefab, parent);
        spell.transform.localScale = hitRadius * spell.transform.localScale;
        base.Cast(parent, position, direction);
    }

    public void Effect(Collider2D target)
    {
        Vector3 direction = target.gameObject.transform.position;
        direction = Vector3.Scale(direction, new Vector3(1f, 1f, 0f));
        direction.Normalize();
        GameObject spell = Instantiate(spellPrefab, target.gameObject.transform);
        spell.transform.localScale = effectRadius * spell.transform.localScale;
        base.Cast(target.gameObject.transform, target.gameObject.transform.position + direction , direction);
    }

    public virtual void Apply(Vector3 position)
    {

    }

}
