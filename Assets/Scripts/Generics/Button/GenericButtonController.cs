using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericButtonController : MonoBehaviour {
    public bool isPressed;
    public bool allowMultiplePresses;
    public Sprite Off;
    public Sprite On;

    public void PressButton() {
        if (!isPressed) {
            isPressed = true;
            Debug.Log("Button was pressed");
            gameObject.GetComponent<SpriteRenderer>().sprite = On;
            if (allowMultiplePresses) {
                StartCoroutine(delayReset());
            }
        }
    }

    private void reset() {
        isPressed = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = Off;
    }

    IEnumerator delayReset() {
        yield return new WaitForSecondsRealtime(1f);
        reset();
    }
}
