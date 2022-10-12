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
    private LevelController levelController;


    public void RestartDialogue() {
        beginDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        cButton.SetActive(true);
        levelController = levelControllerObj.GetComponent<LevelController>();
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
        key.GetComponent<BoxCollider2D>().enabled = false;
        key.SetActive(false);
    }

}
