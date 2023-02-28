using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {

    [SerializeField] GameObject player;
    //[SerializeField] GameObject elevator;
    private GenericLevelLoader genericLevelLoader;
    private PlayerInv playerInv;
    private void Start() {
        playerInv = player.GetComponent<PlayerInv>();
        genericLevelLoader = GetComponent<GenericLevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (playerInv.hasKey == true) {
                Debug.Log("You win!");
                //playerInv.hasKey = false;
                genericLevelLoader.LoadNextLevel();
            } else {
                Debug.Log("Get the key first!");
            }
        }
    }
}
