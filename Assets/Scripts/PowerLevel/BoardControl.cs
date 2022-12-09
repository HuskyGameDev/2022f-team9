using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardControl : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject board;
    [SerializeField] GameObject blocker;
    [SerializeField] GameObject bulb;
    [SerializeField] GameObject darkness;
    [SerializeField] int toSolve;

    bool displayed = false;
    public bool unsolved = true;
    public int current = 0;

    public void increase() {
	current++;
    }

    public void decrease() {
	current--;
    }

    void Update() {
	if(current == toSolve && unsolved){
	    Debug.Log("Puzzle Solved!");
	    blocker.GetComponent<playerStopper>().toggle();
	    bulb.GetComponent<Lights>().lightSwitch();
	    darkness.GetComponent<SpriteRenderer>().enabled = false;
	    unsolved = false;
	    retract();
	}
    }

    public void toggle() {
	if(unsolved){
	    if(!displayed){
	        display();
	    }
	    else {
	    retract();
	    }
	}
    }

    void display() {
	board.transform.position += new Vector3(-33, 0, 0);
	displayed = true;
	Time.timeScale = 0;
    }

    void retract() {
	board.transform.position += new Vector3(33, 0, 0);
	displayed = false;
	Time.timeScale = 1;
    }
}
