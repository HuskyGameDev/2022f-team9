using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator anim;

    private Queue<string> sentences;

    public int currentIndex;

    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {

        anim.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {

        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        currentIndex = sentences.Count;

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue() {
        anim.SetBool("IsOpen", false);
    }

}
