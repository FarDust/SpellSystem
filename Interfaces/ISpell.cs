using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell
{
    void Cast(Transform parent, Vector3 position, Vector3 direction);
}
