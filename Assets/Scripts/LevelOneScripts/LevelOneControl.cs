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

    [Header("Bools")]
    public bool[] buts = { false, false, false, false };

//Level 1 Button order = Red Yellow Blue Green
    private void Start() {
       
    }

    private void Update() {

    }

    public void pressRed() {
	buts[0] = true;
    }

    public void pressYellow() {

	if(buts[0]) {
	    buts[1] = true;
	}
	else {
	    BroadcastMessage("reset");
	}
    }

    public void pressBlue() {

	if(buts[1]) {
	    buts[2] = true;
	}
	else {
	    BroadcastMessage("reset");
	}

    }

    public void pressGreen() {

	if(buts[2]) {
	    buts[3] = true;
	}
	else {
	    BroadcastMessage("reset");
	}

    }

    public void reset() {
	for(int i = 0; i < 4; i++)
	{
	    buts[i] = false;
	}

    }

    public void guide() {
	BroadcastMessage("toggle");	    
    }
}
