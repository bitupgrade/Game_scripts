using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;

    public float runSpeed = 20f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Debug.Log(horizontalMove);

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            runSpeed = 0f;
            anim.SetBool("IsCrouching", true);
        } else if (Input.GetButtonUp("Crouch"))
        {
            runSpeed = 20f;
            anim.SetBool("IsCrouching", false);
        }
    }

    void FixedUpdate()
    {
        // Character movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); // movement, crouch, jump
        jump = false;
    }

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        anim.SetBool("IsCrouching", isCrouching);
    }
}
