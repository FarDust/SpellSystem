using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;
    public List<string> keyBindings;
    private List<float> lastCast;
    public List<GameObject> spellUI;

    private void Start()
    {
        lastCast = new List<float>(new float[spellbook.spells.Count]);
    }
    void Update()
    {
        for (int i = 0; i < spellbook.spells.Count; i++)
        {
            if (spellUI[i] != null && spellbook.spells[i].ReviewCooldown(lastCast[i]))
            {
                spellUI[i].GetComponent<Image>().color = new Color32(255,255,225,255);
            }
            if (Input.GetKeyDown(keyBindings[i]))
            {
                if (spellbook.spells[i].ReviewCooldown(lastCast[i]) || lastCast[i] == 0)
                {
                    lastCast[i] = Time.time;
                    spellbook.spells[i].Cast(transform, transform.position, Vector3.zero);
                    if (spellUI[i] != null)
                    {
                        spellUI[i].GetComponent<Image>().color = new Color32(0, 0, 0, 40);
                    }
                }
            }
        }
    }
}
