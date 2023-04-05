using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_DialogueTrigger : MonoBehaviour {

    public G_Dialogue dialogue;

    public void TriggerDialogue() {
        FindObjectOfType<G_DialogueManager>().StartDialogue(dialogue);
    }

}
