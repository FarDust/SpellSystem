using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BoostSpellController : MonoBehaviour
{

    [SerializeField] public BoostSpell spell;
    public AudioSource source;
    private Coroutine coroutine;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(Activate());
        time = Time.time;
    }

    private void Update()
    {
        if (Time.time - time > spell.duration) {
            Cancel();
        }
    }

    IEnumerator Activate() {
        source.clip = spell.onCastingSound;
        source.loop = true;
        source.Play();
        while (true)
        {
            yield return new WaitForSeconds(spell.castPeriod);
            spell.Apply(transform.position);
        }
    }

    public void Cancel() {
        StopCoroutine(coroutine);
        source.PlayOneShot(spell.onCancelSound);
        Destroy(gameObject);
    }
}
