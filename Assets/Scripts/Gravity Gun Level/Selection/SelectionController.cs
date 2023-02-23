using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour {
    private SwitchController switchController;
    [SerializeField] GameObject textLeft;
    [SerializeField] GameObject textRight;

    private void Start() {
        switchController = GetComponent<SwitchController>();
    }

    private void Update() {
        if (switchController.isSwitched) {
            textLeft.SetActive(false);
            textRight.SetActive(true);
        } else {
            textLeft.SetActive(true);
            textRight.SetActive(false);
        }
    }

}
