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

    private bool hasObj = false;
    private GameObject current;

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
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(worldMousePos);
        if (Input.GetMouseButtonDown(0)) {
            if (TryGetObjAtMousePos(mousePos, out current)) {
                Debug.Log(current);
                hasObj = true;
            } else {
                Debug.Log("no object");
            }
        }
        if (hasObj) {
            //Debug.Log(current);
            current.transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0);
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
