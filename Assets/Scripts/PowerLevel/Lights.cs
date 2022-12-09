using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public Sprite Off;
    public Sprite On;

    public void lightSwitch() {
	 gameObject.GetComponent<SpriteRenderer>().sprite = On;
    }
}
