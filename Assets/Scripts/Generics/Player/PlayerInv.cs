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

    void Update() {
        if (isInRange) {
            if (Input.GetKeyDown(interactKey)) {
                interactAction.Invoke();
            }
        }

        if (hasGravGun) {
            gravGunUpdate();
        }
    }

    private void gravGunUpdate() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject current;
            TryGetObjAtMousePos(Input.mousePosition, out current);
            Debug.Log(current);
        }
    }

    private bool TryGetObjAtMousePos(Vector3 mousePos, out GameObject go) {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider) {
            go = hit.collider.gameObject;
            return true;
        } else {
            go = null;
            return false;
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
