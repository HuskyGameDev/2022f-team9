using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGunPickupController : MonoBehaviour {

    [SerializeField] public GameObject player;
    [SerializeField] public SpriteRenderer outline;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player.GetComponent<PlayerInv>().hasGravGun = true;
            outline.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
