using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlayerController controller;

    public float runSpeed = 40f;

    float horizontalDir = 0f;
    bool jump = false;
    bool crouch = false;

    void Update() {

        horizontalDir = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

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
