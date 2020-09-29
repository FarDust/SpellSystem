using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;

    void Update()
    {
        if (Input.GetKeyDown("g")) {
            spellbook.spells[0].Cast(transform, transform.position, transform.forward);
        }
    }
}
