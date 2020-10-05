using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    public float climbSpeed = 400f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal_wizard") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        verticalMove = Input.GetAxisRaw("Vertical_wizard") * climbSpeed;
        animator.SetBool("isClimbing", controller.isClimbing);

        if (controller.isClimbing && 
            (Mathf.Abs(verticalMove) < .1f || controller.topLadder || controller.bottomLadder)) {
            animator.speed = 0f;
        }
        else {
            animator.speed = 1f;
        }

        if (Input.GetButtonDown("Jump_wizard")){
            jump = true;
            SoundManagingScript.PlaySound("wizardJump");
            animator.SetBool("isJumping", true);
        }
    }

    public void OnLanding(){
        animator.SetBool("isJumping", false);
    }

    public void BlockActions() {
        enabled = false;
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
