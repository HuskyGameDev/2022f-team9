using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out PlayerInv playerInv)) {
            if (playerInv.hasKey == true) {
                Debug.Log("You win!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else {
                Debug.Log("Get the key first!");
            }
        }
    }
}
