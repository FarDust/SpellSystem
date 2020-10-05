﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;
    private int spellNumber = 0;
    public Animator animator;
    private CharacterController2D movement;

    private void Start()
    {
        movement = gameObject.GetComponent<CharacterController2D>();
    }

    void Update(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0){
            spellNumber = spellNumber + 1;
            if (spellNumber >= spellbook.spells.Count){
                spellNumber = 0;
            }

        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            spellNumber = spellNumber - 1;
            if (spellNumber < 0){
                spellNumber = spellbook.spells.Count - 1;
            }
        }

        if (Input.GetButtonDown("Spell_wizard")){
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            Vector3 direction = worldMousePosition - gameObject.transform.position;
            direction = Vector3.Scale(direction, new Vector3(1f, 1f, 0f));
            direction.Normalize();
            transform.forward = Vector3.Cross(direction, new Vector3(1f, 1f, 0f)).normalized;
            StartCoroutine(spellDelay(0.5f));
            animator.SetTrigger("Attack");
            spellbook.spells[spellNumber].Cast(transform, transform.position + direction , direction);
        }
    }

    private IEnumerator spellDelay(float seconds) {
        movement.enabled = false;
        yield return new WaitForSeconds(seconds);
        movement.enabled = true;
    }
}
