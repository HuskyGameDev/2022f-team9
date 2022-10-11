using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

    //checking if player hits the key
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && collision.TryGetComponent(out PlayerInv playerInv)) {
            playerInv.hasKey = true;
        }
    }

}
