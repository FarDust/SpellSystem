﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpellController : MonoBehaviour
{
    [SerializeField] public DamageSpell spell;
    public LayerMask targetLayers;
    public LayerMask explodeLayers;
    public AudioSource source;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * (float)(Mathf.Pow(spell.projectileVelocity, 2) * 0.5));
        source.loop = true;
        StartCoroutine(playSpellSound());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((explodeLayers.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            spell.OnHit(collision.gameObject);
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, spell.hitRadius, targetLayers);
            foreach(Collider2D target in collisions)
            {
                if (target.gameObject != collision.gameObject)
                {
                    spell.OnHit(target.gameObject);
                }
            }
            source.Stop();
            AudioSource.PlayClipAtPoint(spell.onHitSound, gameObject.transform.position, 1f);
            StartCoroutine(FlashAway());
        }
    }

    IEnumerator playSpellSound()
    {
        source.PlayOneShot(spell.onCreateSound);
        yield return new WaitForSeconds(spell.onCreateSound.length);
        source.clip = spell.onTravelSound;
        source.Play();
    }

    IEnumerator FlashAway() {
        GameObject effect = Instantiate(spell.onDestroyEffect, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(effect.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
}
