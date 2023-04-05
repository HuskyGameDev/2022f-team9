using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_BeginDialogueController : MonoBehaviour {

    [SerializeField] GameObject button1, button2;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GetComponent<G_DialogueTrigger>().TriggerDialogue();
            button1.SetActive(true);
            button2.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
