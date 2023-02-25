using UnityEngine;

public class TranstionScript : MonoBehaviour {

    [SerializeField] GameObject cameraObj;
    private CameraMovementController controller;

    private void Start() {
        controller = cameraObj.GetComponent<CameraMovementController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (collision.transform.position.x > 16.5) {
                controller.MoveToPrevRoom();
            } else {
                controller.MoveToNewRoom();
            }
        }
    }

}
