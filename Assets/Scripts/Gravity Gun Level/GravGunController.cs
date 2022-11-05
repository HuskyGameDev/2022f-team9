using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGunController : MonoBehaviour {

    private GameObject current;
    private bool hasObj = false;

    public void gravGunUpdate() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0)) {
            if (!hasObj) {
                if (TryGetObjAtMousePos(mousePos, out current)) {
                    Debug.Log(current);
                    current.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                    hasObj = true;
                } else {
                    Debug.Log("no object");
                }
            } else {
                current.GetComponent<Rigidbody2D>().gravityScale = 3.5f;
                current = null; //drop current, hopefully
                hasObj = false;
            }
        }

        if (hasObj) {
            current.transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0);
        }
    }

    private bool TryGetObjAtMousePos(Vector3 mousePos, out GameObject go) {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider && hit.collider.gameObject.CompareTag("Movable")) {
            go = hit.collider.gameObject;
            return true;
        } else {
            go = null;
            return false;
        }
    }
}
