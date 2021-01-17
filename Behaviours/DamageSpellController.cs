using System;
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
            if ((targetLayers.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer) {
                spell.OnHit(collision.gameObject);
            }
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, spell.hitRadius, targetLayers);
            foreach(Collider2D target in collisions)
            {
                if (target.gameObject != collision.gameObject)
                {
                    spell.OnHit(target.gameObject);
                }
            }
            source.Stop();
            AudioSource.PlayClipAtPoint(spell.onHitSound, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -8), 1f);
            StartCoroutine(FlashAway());
        }
    }

    IEnumerator playSpellSound()
    {
        AudioSource.PlayClipAtPoint(spell.onCreateSound, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -8), 1f);
        yield return new WaitForSeconds(spell.onCreateSound.length);
        source.clip = spell.onTravelSound;
        source.Play();
    }

    IEnumerator FlashAway() {
        GameObject effect = Instantiate(spell.onDestroyEffect, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        body.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(effect.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
}
