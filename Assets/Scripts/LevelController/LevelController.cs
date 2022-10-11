using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    //"dC" stands for "DialogueController"
    [SerializeField] GameObject dC;
    //"dM" stands for "DialogueManager"
    private DialogueManager dM;

    private void Start() {
        dM = dC.GetComponent<DialogueManager>();
    }

    private void Update() {
        if(dM.sentences.Count == 1) {

        }
    }

}
