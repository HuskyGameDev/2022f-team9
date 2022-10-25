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

    //Level 1 Button order = Red Yellow Blue Green

    public void pressRed() {

	lc.buts[0] = true;
	PressButton();

    }

    public void pressYellow() {

	if(lc.buts[0]) {
	    lc.buts[1] = true;
	    PressButton();
	}
	else {
	    reset();
	}
    }

    public void pressBlue() {

	if(lc.buts[1]) {
	    lc.buts[2] = true;
	    PressButton();
	}
	else {
	    reset();
	}

    }

    public void pressGreen() {

	if(lc.buts[2]) {
	    lc.buts[3] = true;
	    PressButton();
	}
	else {
	    reset();
	}

    }

    private void Update() {

	if(!lc.buts[0]) {
	    isPressed = false;
	    gameObject.GetComponent<SpriteRenderer>().sprite = Off;
	}

    }

    private void reset() {

	for(int i = 0; i < 4; i++)
	{
	    lc.buts[i] = false;
	}
	isPressed = false;
	gameObject.GetComponent<SpriteRenderer>().sprite = Off;
    }

}
