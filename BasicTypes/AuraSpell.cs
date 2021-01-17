using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSpell : BaseSpell
{
    public AudioClip onCreateSound;
    public AudioClip onCastingSound;
    public AudioClip onCancelSound;

    public LayerMask targetLayers;
    public float hitRadius;
    public float castPeriod;
    public float duration;
    public GameObject spellPrefab;

    public override void Cast(Transform parent, Vector3 position, Vector3 direction)
    {
        GameObject spell = Instantiate(spellPrefab, parent);
        spell.transform.localScale = hitRadius * spell.transform.localScale;
        base.Cast(parent, position, direction);
    }

    public virtual void Apply(Vector3 position)
    {

    }

}
