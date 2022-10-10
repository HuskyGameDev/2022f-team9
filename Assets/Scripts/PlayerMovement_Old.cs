using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Old : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    //private Animator anim;
    private BoxCollider2D boxCollider;
    //private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake() {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if (Input.GetKey(KeyCode.Space)) {
            Jump();
        }

        //Flip player when moving left-right
        if (horizontalInput > 0.01f) {
            transform.localScale = Vector3.one;
        } else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Set animator parameters
        /*anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
*/
    }

    private void Jump() {
        if (isGrounded()) {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            //anim.SetTrigger("jump");
        } /*else if (onWall() && !isGrounded()) {
            if (horizontalInput != 1 && horizontalInput != -1) {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 6);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCooldown = 0;
        }*/
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
