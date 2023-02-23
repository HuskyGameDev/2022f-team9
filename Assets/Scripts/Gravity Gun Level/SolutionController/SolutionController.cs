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
            if (keyLeft.transform.eulerAngles.z <= 0.01f && keyRight.transform.eulerAngles.z <= 0.01f) {
                // summon key
                Debug.Log("Correct Solution!");
                Debug.Log(keyLeft.transform.eulerAngles.z);
                Debug.Log(keyRight.transform.eulerAngles.z);
                key.SetActive(true);
            } else {
                Debug.Log(keyLeft.transform.eulerAngles.z);
                Debug.Log(keyRight.transform.eulerAngles.z);
                levelController.resetBoxPos();
                keyLeft.transform.rotation = Quaternion.Euler(0, 0, 90);
                keyRight.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}
