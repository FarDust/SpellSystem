using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal_warrior") * runSpeed;
        animator.SetFloat("Warrior_Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump_warrior")){
            jump = true;
            animator.SetBool("Warrior_isJumping", true);
        }
    }

    public void OnLanding(){
        animator.SetBool("Warrior_isJumping", false);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
