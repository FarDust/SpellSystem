using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;
    public List<string> keyBindings;

    void Update()
    {
        if (Input.GetKeyDown(keyBindings[0]))
        {
            spellbook.spells[0].Cast(transform, transform.position, Vector3.zero);
        }
    }
}
