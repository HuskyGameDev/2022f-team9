using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDenierController : MonoBehaviour {

    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;
    private void Start() {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerMovement.canJump = false;
            StartCoroutine(resetJump());
        }
    }

    private IEnumerator resetJump() {
        yield return new WaitForSeconds(0.5f);
        playerMovement.canJump = true;
    }

}
