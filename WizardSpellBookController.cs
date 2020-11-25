using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        if (spellbook.spells[spellNumber].ReviewCooldown(lastCast[spellNumber]) || lastCast[spellNumber] == 0){
            spellUI.GetComponent<Image>().color = new Color32(255,255,225,255);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0){
            spellNumber = spellNumber + 1;
            if (spellNumber >= spellbook.spells.Count){
                spellNumber = 0;
            }
            SetCurrentSpell();
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            spellNumber = spellNumber - 1;
            if (spellNumber < 0){
                spellNumber = spellbook.spells.Count - 1;
            }
            SetCurrentSpell();
        }

        if ( !EventSystem.current.IsPointerOverGameObject() && Input.GetButtonDown("Spell_wizard"))
        {
            if (spellbook.spells[spellNumber].ReviewCooldown(lastCast[spellNumber]) || lastCast[spellNumber] == 0) {
                lastCast[spellNumber] = Time.time;
                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
                Vector3 direction = worldMousePosition - gameObject.transform.position;
                direction = Vector3.Scale(direction, new Vector3(1.5f, 1.5f, 0f));
                direction.Normalize();
                transform.forward = Vector3.Cross(direction, new Vector3(1f, 1f, 0f)).normalized;
                StartCoroutine(spellDelay(0.5f));
                animator.SetTrigger("Attack");
                spellbook.spells[spellNumber].Cast(transform, transform.position + direction, direction);
                spellUI.GetComponent<Image>().color = new Color32(255,255,225,40);
            }
        }
    }

    private IEnumerator spellDelay(float seconds) {
        movement.enabled = false;
        yield return new WaitForSeconds(seconds);
        movement.enabled = true;
    }
    void SetCurrentSpell(){
        // The spell is black if you can't cast it
        if (spellbook.spells[spellNumber].ReviewCooldown(lastCast[spellNumber]) || lastCast[spellNumber] == 0){
            spellUI.GetComponent<Image>().color = new Color32(255,255,225,255);
        } 
        else {
            spellUI.GetComponent<Image>().color = new Color32(255,255,225,40);
        }
        currentFrame = (float)spellNumber/(float)spellbook.spells.Count;
        spellUI.GetComponent<Animator>().Play("CurrentSpell", 0, currentFrame);
    }
}
