﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSpellBookController : MonoBehaviour
{
    public SpellBook spellbook;
    private int spellNumber = 0;
    public Animator animator;
    public GameObject spellUI;
    private float currentFrame = 0f;
    private CharacterController2D movement;
    private List<float> lastCast;

    private void Start()
    {
        movement = gameObject.GetComponent<CharacterController2D>();
        lastCast = new List<float>(new float[spellbook.spells.Count]);
        
    }


    void Update(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0){
            spellNumber = spellNumber + 1;
            if (spellNumber >= spellbook.spells.Count){
                spellNumber = 0;
            }
            currentFrame = (float)spellNumber/(float)spellbook.spells.Count;
            Debug.Log(currentFrame);
            spellUI.GetComponent<Animator>().Play("CurrentSpell", 0, currentFrame);
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            spellNumber = spellNumber - 1;
            if (spellNumber < 0){
                spellNumber = spellbook.spells.Count - 1;
            }
            currentFrame = (float)spellNumber/(float)spellbook.spells.Count;
            Debug.Log(currentFrame);
            spellUI.GetComponent<Animator>().Play("CurrentSpell", 0, currentFrame);
        }

        if (Input.GetButtonDown("Spell_wizard"))
        {
            if (spellbook.spells[spellNumber].ReviewCooldown(lastCast[spellNumber]) || lastCast[spellNumber] == 0) {
                lastCast[spellNumber] = Time.time;
                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
                Vector3 direction = worldMousePosition - gameObject.transform.position;
                direction = Vector3.Scale(direction, new Vector3(1f, 1f, 0f));
                direction.Normalize();
                transform.forward = Vector3.Cross(direction, new Vector3(1f, 1f, 0f)).normalized;
                StartCoroutine(spellDelay(0.5f));
                animator.SetTrigger("Attack");
                spellbook.spells[spellNumber].Cast(transform, transform.position + direction, direction);
            }
        }
    }

    private IEnumerator spellDelay(float seconds) {
        movement.enabled = false;
        yield return new WaitForSeconds(seconds);
        movement.enabled = true;
    }
}
