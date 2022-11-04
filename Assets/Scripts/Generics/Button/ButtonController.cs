using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    public Sprite Off;
    public Sprite On;
    public LevelOneControl lc;

    public void PressButton() {
        if (!isPressed) {
            isPressed = true;
            Debug.Log("Button was pressed");
	    gameObject.GetComponent<SpriteRenderer>().sprite = On;
        }
    }

    private void reset() {
	isPressed = false;
	gameObject.GetComponent<SpriteRenderer>().sprite = Off;
    }
}
