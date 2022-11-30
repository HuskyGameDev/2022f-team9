using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStopper : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] bool big = false;

    public void toggle() {
	big = !big;
	if(big) {
	    wall.GetComponent<BoxCollider2D>().isTrigger = false;
	}
	else {
	    wall.GetComponent<BoxCollider2D>().isTrigger = true;
	}
    }
}
