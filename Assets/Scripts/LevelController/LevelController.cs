using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    //"dM" stands for "DialogueManager"
    [SerializeField] DialogueManager dM;
    //"cButton" stands for "ContinueButton"
    [SerializeField] GameObject cButton;

    private bool cont1, run1 = false;

    private void Update() {
        if (!run1 && dM.currentIndex == 2) {
            cButton.SetActive(false);
            run1 = true;
            StartCoroutine(Delay());
        }

        if (cont1 && Input.GetButtonDown("Jump")) {
            cont1 = false;
            dM.DisplayNextSentence();
            cButton.SetActive(true);
        }
    }

    private IEnumerator Delay() {
        yield return new WaitForSeconds(3f);
        cont1 = true;
    }

}
