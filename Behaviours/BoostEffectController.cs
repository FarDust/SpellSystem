using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BoostEffectController : MonoBehaviour
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
        if (Time.time - time > spell.effectDuration) {
            Cancel();
        }
    }

    IEnumerator Activate() {
        source.clip = spell.onEffectSound;
        source.loop = false;
        source.Play();
        yield return new WaitForSeconds(spell.onEffectSound.length);
    }

    public void Cancel() {
        StopCoroutine(coroutine);
        source.PlayOneShot(spell.onCancelSound);
        Destroy(gameObject);
    }
}
