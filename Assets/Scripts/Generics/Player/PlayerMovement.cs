using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlayerController controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalDir = 0f;
    public bool canJump;
    bool jump = false;
    bool crouch = false;
    float vertVel = 0f;

    private void Start() {
        canJump = true;
    }

    void Update() {
        horizontalDir = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalDir));

        if (Input.GetButtonDown("Jump") && canJump) {
            jump = true;
        }
        animator.SetFloat("vertVelocity", GetComponentInParent<Rigidbody2D>().velocity.y);

        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

    }

    private void FixedUpdate() {

        controller.Move(horizontalDir * Time.fixedDeltaTime, crouch, jump);
        jump = false;



    }
}
