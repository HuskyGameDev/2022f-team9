using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : GenericLevelLoader {

    [SerializeField] GameObject player;
    private PlayerInv playerInv;
    private void Start() {
        playerInv = player.GetComponent<PlayerInv>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (playerInv.hasKey == true) {
                Debug.Log("You win!");
                playerInv.hasKey = false;
                LoadNextLevel();
            } else {
                Debug.Log("Get the key first!");
            }
        }
    }
}
