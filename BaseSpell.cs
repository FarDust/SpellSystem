using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : ScriptableObject, ISpell
{

    public float cooldown;
    public virtual void Cast(Transform parent, Vector3 position, Vector3 direction)
    {

    }
    public bool ReviewCooldown(float lastcast){
        return ((Time.time - lastcast) > cooldown);
    }
}
