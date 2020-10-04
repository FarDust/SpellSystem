using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float defaultRunSpeed;
    public float climbSpeed = 100f;
    float defaultClimbSpeed;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    float increaseSpeedTimer = 0f;
    float increaseJumpTimer = 0f;
    public float boostDuration = 20f;

private void Awake() {
		defaultRunSpeed = runSpeed;
        defaultClimbSpeed = climbSpeed;
	}

    // Update is called once per frame
    void Update() {
        if (Time.time >= increaseJumpTimer){
            controller.m_JumpForce = controller.defaultJumpForce;
        }
        if (Time.time >= increaseSpeedTimer){
            runSpeed = defaultRunSpeed;
            climbSpeed = defaultClimbSpeed;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal_warrior") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        verticalMove = Input.GetAxisRaw("Vertical_warrior") * climbSpeed;
        animator.SetBool("isClimbing", controller.isClimbing);

        if (controller.isClimbing && 
            (Mathf.Abs(verticalMove) < .1f || controller.topLadder || controller.bottomLadder)) {
            animator.speed = 0f;
        }
        else {
            animator.speed = 1f;
        }

        if (Input.GetButtonDown("Jump_warrior")){
            jump = true;
            SoundManagingScript.PlaySound("warriorJump");
            animator.SetBool("isJumping", true);
        }
    }

    public void IncreaseJump(float multiplier){
        increaseJumpTimer = Time.time + boostDuration;
        controller.m_JumpForce = controller.m_JumpForce * multiplier;
    }

    public void IncreaseSpeed(float multiplier){
        increaseSpeedTimer = Time.time + boostDuration;
        runSpeed = runSpeed * multiplier;
        climbSpeed = climbSpeed * multiplier;
    }

    public void OnLanding() {
        animator.SetBool("isJumping", false);
    }

    public void BlockActions() {
        gameObject.GetComponent<WarriorMovement>().enabled = false;
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
