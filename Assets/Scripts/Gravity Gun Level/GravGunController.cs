using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGunController : MonoBehaviour {

    public GameObject current;
    [SerializeField] GameObject player;
    public Rigidbody2D currentBody;
    [SerializeField] OutlineController outlineController;

    public int gravGunMaxSpeed;
    public float minSpeedDist;
    public float maxSpeedDist;
    public float speedPercent;
    public float speedNow;


    public double gravGunRadius;
    public float distToObj;
    public bool hasObj = false;

    public void gravGunUpdate() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 worldMousePosAdj = new(worldMousePos.x, worldMousePos.y, worldMousePos.z + 10);

        //Debug.Log(Vector3.Distance(player.transform.position, worldMousePos));

        if (Input.GetMouseButtonDown(0) && Vector3.Distance(player.transform.position, worldMousePosAdj) < gravGunRadius) {
            if (!hasObj) {
                if (TryGetObjAtMousePos(mousePos, out current)) {
                    //Debug.Log(current);
                    objState(true);
                } else {
                    //Debug.Log("no object");
                }
            } else {
                current = null; //drop current, hopefully
                objState(false);
            }
        }

        if (hasObj) {
            distToObj = Vector3.Distance(current.transform.position, worldMousePosAdj);
            //Debug.Log(distToObj);
            if (Vector3.Distance(current.transform.position, player.transform.position) < gravGunRadius
                    && Vector3.Distance(worldMousePosAdj, player.transform.position) < gravGunRadius) {
                speedPercent = Mathf.InverseLerp(minSpeedDist, maxSpeedDist, distToObj);
                speedNow = Mathf.Lerp(0, gravGunMaxSpeed, speedPercent);
                currentBody.velocity = ((worldMousePosAdj - current.transform.position).normalized * speedNow);
            } else {
                current = null;
                currentBody = null;
                objState(false);
            }
        }
    }

    public void objState(bool arg) {
        if (arg) {
            hasObj = true;
            outlineController.changeOutline(2);
            //currentBody.mass = 0;
        } else {
            hasObj = false;
            outlineController.changeOutline(1);
            //currentBody.mass = 1;
        }
    }

    private bool TryGetObjAtMousePos(Vector3 mousePos, out GameObject go) {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider && hit.collider.gameObject.CompareTag("Movable")) {
            go = hit.collider.gameObject;
            currentBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            return true;
        } else {
            go = null;
            return false;
        }
    }
}
