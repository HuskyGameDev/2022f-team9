using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour {

    [Header("Manager, Continue and Restart Button")]
    //"dM" stands for "DialogueManager"
    [SerializeField] DialogueManager dM;
    //"cButton" stands for "ContinueButton"
    //"rButton" stands for "RestartButton"
    [SerializeField] GameObject cButton;
    [SerializeField] GameObject rButton;

    [Header("Key, Player, and Elevator")]
    [SerializeField] GameObject key;
    [SerializeField] GameObject player;
    [SerializeField] GameObject elevator;
    private PlayerInv playerInv;

    [Header("Button for the key")]
    [SerializeField] GameObject buttonBack;
    [SerializeField] GameObject button;
    private ButtonController buttonController;
    [SerializeField] GameObject buttonInteraction;

    [Header("Detectors")]
    [SerializeField] GameObject detector0;
    [SerializeField] GameObject detector1;
    private DetectorController detector0Controller;
    private DetectorController detector1Controller;
    [Header("Bools")]
    public bool[] cont = { false, false, false, false, false, false };
    public bool[] run = { false, false, false, false, false, false };
    public bool canCont;

    private void Start() {
        detector0Controller = detector0.GetComponent<DetectorController>();
        detector1Controller = detector1.GetComponent<DetectorController>();
        playerInv = player.GetComponent<PlayerInv>();
        buttonController = button.GetComponent<ButtonController>();
    }

    private void Update() {

        if (!run[0] && dM.currentElement == 2) {
            run[0] = true;
            cButton.SetActive(false);
            canCont = false;
            StartCoroutine(Delay(val => cont[0] = val));
        }
        if (cont[0] && Input.GetButtonDown("Jump")) {
            cont[0] = false;
            StartCoroutine(NextSentenceDelay());
        }

        if (!run[1] && dM.currentElement == 4) {
            run[1] = true;
            cButton.SetActive(false);
            canCont = false;
            StartCoroutine(DelayDetector(val => cont[1] = val, detector0));
        }
        if (cont[1] && detector0Controller.hitPlayer) {
            cont[1] = false;
            detector0.SetActive(false);
            StartCoroutine(NextSentenceDelay());
        }
        
        if (!run[2] && dM.currentElement == 6) {
            run[2] = true;
            cButton.SetActive(false);
            canCont = false;
            StartCoroutine(DelayDetector(val => cont[2] = val, detector1));
        }
        if (cont[2] && detector1Controller.hitPlayer) {
            cont[2] = false;
            detector1.SetActive(false);
            StartCoroutine(NextSentenceDelay());
        }

        if (!run[3] && dM.currentElement == 8) {
            run[3] = true;
            buttonBack.SetActive(true);
            button.SetActive(true);
            buttonInteraction.SetActive(true);
            cButton.SetActive(false);
            canCont = false;
            StartCoroutine(Delay(val => cont[3] = val));
        }
        if (cont[3] && buttonController.isPressed) {
            cont[3] = false;
            StartCoroutine(NextSentenceDelay());
        }
        if (!run[4] && dM.currentElement == 9) {
            run[4] = true;
            cButton.SetActive(false);
            canCont = false;
            key.SetActive(true);
            key.GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(Delay(val => cont[4] = val));
        }
        if (cont[4] && playerInv.hasKey) {
            cont[4] = false;
            StartCoroutine(NextSentenceDelay());
        }

        if (!run[5] && dM.currentElement == 12) {
            run[5] = true;
            StartCoroutine(DelayElevator(elevator));
        }
    }

    private IEnumerator NextSentenceDelay() {
        yield return new WaitForSeconds(1f);
        dM.DisplayNextSentence();
        cButton.SetActive(true);
        canCont = true;
    }

    private IEnumerator Delay(Action<bool> callback) {
        yield return new WaitForSeconds(3f);
        callback(true);
    }

    private IEnumerator DelayLong(Action callback0, Action callback1, Action callback2) {
        yield return new WaitForSeconds(5f);
        callback0();
        callback1();
        callback2();
    }

    //Temporarily gone for playtesting
    /*private IEnumerator DelayKey(Action<bool> callback, GameObject key) {
        yield return new WaitForSeconds(2f);
        key.GetComponent<BoxCollider2D>().enabled = true;
        callback(true);
    }*/

    private IEnumerator DelayElevator(GameObject elevator) {
        yield return new WaitForSeconds(3f);
        elevator.GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(DelayLong(() => dM.DisplayNextSentence(), () => cButton.SetActive(false),
            () => rButton.SetActive(false)));
    }

    private IEnumerator DelayDetector(Action<bool> callback, GameObject detectorX) {
        yield return new WaitForSeconds(3f);
        callback(true);
        detectorX.SetActive(true);
    }

}
