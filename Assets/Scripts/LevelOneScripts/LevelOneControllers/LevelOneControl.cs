using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelOneControl : MonoBehaviour {

    [Header("RedButton, GreenButton, BlueButton, YellowButton")]
    [SerializeField] GameObject RButton;
    [SerializeField] GameObject GButton;
    [SerializeField] GameObject BButton;
    [SerializeField] GameObject YButton;
    private ButtonController RButtonController;

    [Header("Player, and Elevator")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject elevator;
    private PlayerInv playerInv;

    //[Header("Detectors")]
    //[SerializeField] GameObject detector0;
    //[SerializeField] GameObject detector1;
    //private DetectorController detector0Controller;
    //private DetectorController detector1Controller;
    [Header("Bools")]
    //public bool[] cont = { false, false, false, false, false, false };
    public bool[] buts = { false, false, false, false };


    private void Start() {
        RButtonController = RButton.GetComponent<ButtonController>();
    }

    private void Update() {
        //RButtonController.isPressed;
    }

    /*

    DIALOUGE CODE COMMENTED OUT UNTIL IT IS DETERMINED TO BE NEEDED OR NOT

        private void Start() {
            detector0Controller = detector0.GetComponent<DetectorController>();
            detector1Controller = detector1.GetComponent<DetectorController>();
            playerInv = player.GetComponent<PlayerInv>();
        }



        private void Update() {


        }

        private IEnumerator NextSentenceDelay() {
            yield return new WaitForSeconds(1f);
            dM.DisplayNextSentence();
            cButton.SetActive(true);
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

        private IEnumerator DelayKey(Action<bool> callback, GameObject key) {
            yield return new WaitForSeconds(2f);
            key.GetComponent<BoxCollider2D>().enabled = true;
            callback(true);
        }

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
    */
}
