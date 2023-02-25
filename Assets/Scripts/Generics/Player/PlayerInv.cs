using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInv : MonoBehaviour {

    public bool hasKey;
    public bool isInRange;
    public bool hasGravGun;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    private GravGunController gravGunController;

    /*private bool hasObj = false;
    private GameObject current;*/

    private void Start() {
        gravGunController = gameObject.GetComponent<GravGunController>();
    }

    void Update() {
        if (isInRange) {
            if (Input.GetKeyDown(interactKey)) {
                interactAction.Invoke();
            }
        }

        if (hasGravGun) {
            gravGunController.gravGunUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = false;
            Debug.Log("Player not in range");
        }
    }
}
