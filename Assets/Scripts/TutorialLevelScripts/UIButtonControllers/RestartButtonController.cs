using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonController : MonoBehaviour {

    [SerializeField] GameObject beginDialogue;
    [SerializeField] GameObject cButton;
    [SerializeField] GameObject levelControllerObj;
    [SerializeField] GameObject detector0;
    [SerializeField] GameObject detector1;
    [SerializeField] GameObject key;
    [SerializeField] GameObject buttonBack;
    [SerializeField] GameObject button;
    [SerializeField] GameObject interaction;
    private LevelController levelController;
    private ButtonController buttonController;

    private void Start() {
        levelController = levelControllerObj.GetComponent<LevelController>();
        buttonController = button.GetComponent<ButtonController>();
    }
    public void RestartDialogue() {
        beginDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        cButton.SetActive(true);
        for(int i = 0; i < levelController.cont.Length; i++) {
            levelController.cont[i] = false;
        }
        for (int i = 0; i < levelController.run.Length; i++) {
            levelController.run[i] = false;
        }
        detector0.SetActive(false);
        detector1.SetActive(false);
        detector0.GetComponent<DetectorController>().hitPlayer = false;
        detector1.GetComponent<DetectorController>().hitPlayer = false;
        buttonController.isPressed = false;
        buttonBack.SetActive(false);
        button.SetActive(false);
        interaction.SetActive(false);
        key.GetComponent<BoxCollider2D>().enabled = false;
        key.SetActive(false);
    }

}
