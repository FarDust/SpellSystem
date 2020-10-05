using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;
    public List<string> keyBindings;
    private List<float> lastCast;
    public GameObject spellUI;

    private void Start()
    {
        lastCast = new List<float>(new float[spellbook.spells.Count]);
    }
    void Update()
    {
        if (spellbook.spells[0].ReviewCooldown(lastCast[0])){
            spellUI.GetComponent<Image>().color = new Color32(255,255,225,255);
        }
        if (Input.GetKeyDown(keyBindings[0]))
        {
            if (spellbook.spells[0].ReviewCooldown(lastCast[0]) || lastCast[0] == 0)
            {
                lastCast[0] = Time.time;
                spellbook.spells[0].Cast(transform, transform.position, Vector3.zero);
                spellUI.GetComponent<Image>().color = new Color32(0,0,0,40);
            }
        }
    }
}
