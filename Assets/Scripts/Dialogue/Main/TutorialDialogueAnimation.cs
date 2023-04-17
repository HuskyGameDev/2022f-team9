using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogueAnimation : MonoBehaviour {

    public Animator anim;
    public GameObject dmObj;
    public DialogueManager dm;

    private void Start() {
        dm = dmObj.GetComponent<DialogueManager>();
        //anim.SetBool("Hide", true);
    }
    private void Update() {
        if (dm.endAnim) {
            anim.SetBool("Hide", true);
        }
    }
}
