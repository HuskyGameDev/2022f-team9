using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimation : MonoBehaviour {

    public Animator anim;
    public GameObject dmObj;
    public G_DialogueManager dm;

    private void Start() {
        dm = dmObj.GetComponent<G_DialogueManager>();
        //anim.SetBool("Hide", true);
    }

    private void Update() {
        if (dm.endAnim) {
            //Debug.Log("setting bool");
            anim.SetBool("Hide", true);
        }
    }
}
