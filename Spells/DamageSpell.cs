using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSpell : BaseSpell, IOnHit
{
    public AudioClip onHitSound;
    public AudioClip onTravelSound;
    public AudioClip onCreateSound;
    public float damage;
    public float hitRadius;
    public float projectileVelocity;
    public GameObject spellPrefab;
    public GameObject onDestroyEffect;

    public override void Cast(Transform parent, Vector3 position, Vector3 direction) {
        Quaternion lookAt = Quaternion.FromToRotation(new Vector3(1f, 0f, 0f), direction);
        Instantiate(spellPrefab, position, lookAt);
        base.Cast(parent, position, direction);
    }

    public virtual void OnHit(GameObject target) {
        target.SendMessage("TakeHit", damage);
    }
}
