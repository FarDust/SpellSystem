using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpellBook", order = 1)]
public class SpellBook : ScriptableObject
{
    public string spellbookName;
    public List<BaseSpell> spells;
}
