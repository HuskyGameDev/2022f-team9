using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class G_DialogueManager : MonoBehaviour {

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator anim;

    private Queue<string> sentences;

    public int currentElement = 0;

    void Start() {
        sentences = new Queue<string>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(G_Dialogue dialogue) {

        //anim.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        currentElement = 0;
    }

    public void DisplayNextSentence() {

        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        currentElement++;

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    void EndDialogue() {
        //anim.SetBool("IsOpen", false);
    }

}
