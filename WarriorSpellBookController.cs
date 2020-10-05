using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;
    public List<string> keyBindings;
    private List<float> lastCast;

    private void Start()
    {
        lastCast = new List<float>(new float[spellbook.spells.Count]);

    }
    void Update()
    {
        if (Input.GetKeyDown(keyBindings[0]))
        {
            if (spellbook.spells[0].ReviewCooldown(lastCast[0]) || lastCast[0] == 0)
            {
                lastCast[0] = Time.time;
                spellbook.spells[0].Cast(transform, transform.position, Vector3.zero);
            }
        }
    }
}
