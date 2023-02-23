using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionController : MonoBehaviour {
    [SerializeField] GameObject keyLeft;
    [SerializeField] GameObject keyRight;
    [SerializeField] GameObject key;
    [SerializeField] GameObject levelControllerObj;
    private GravGunLevelController levelController;

    private void Start() {
        levelController = levelControllerObj.GetComponent<GravGunLevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Movable")) {
            if (Vector3.Angle(keyLeft.transform.right, Vector3.right) < 0.01f && Vector3.Angle(keyRight.transform.right, Vector3.right) < 0.01f) {
                key.SetActive(true);
                Debug.Log(keyLeft.transform.right);
                Debug.Log(keyRight.transform.right);
            } else {
                Debug.Log(keyLeft.transform.right);
                Debug.Log(keyRight.transform.right);
                levelController.resetBoxPos();
                keyLeft.transform.rotation = Quaternion.Euler(0, 0, 90);
                keyRight.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}
