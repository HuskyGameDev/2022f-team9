using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {

    [SerializeField] GameObject switchObj;
    private SwitchController switchController;

    public bool rotateRight = false;
    public bool rotateLeft = false;

    [Header("Key Sprites")]
    [SerializeField] GameObject keyLeft;
    [SerializeField] GameObject keyRight;

    private void Start() {
        switchController = switchObj.GetComponent<SwitchController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Movable")) {
            if (rotateRight) {
                if (switchController.isSwitched) {
                    keyRight.transform.Rotate(0, 0, -90, Space.World);
                } else {
                    keyLeft.transform.Rotate(0, 0, -90, Space.World);
                }
            } else if (rotateLeft) {
                if (switchController.isSwitched) {
                    keyRight.transform.Rotate(0, 0, 90, Space.World);
                } else {
                    keyLeft.transform.Rotate(0, 0, 90, Space.World);
                }
            }
        }
    }

}
