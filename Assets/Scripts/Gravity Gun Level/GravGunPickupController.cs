using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGunPickupController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerInv>().hasGravGun = true;
            gameObject.SetActive(false);
        }
    }
}
