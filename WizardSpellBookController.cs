using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            Vector3 direction = worldMousePosition - gameObject.transform.position;
            direction = Vector3.Scale(direction, new Vector3(1f, 1f, 0f));
            direction.Normalize();
            transform.forward = Vector3.Cross(direction, new Vector3(1f, 1f, 0f)).normalized;
            animator.SetTrigger("Attack");
            spellbook.spells[0].Cast(transform, transform.position + direction , direction);
        }
    }
}
