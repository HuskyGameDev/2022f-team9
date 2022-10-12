using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;

    public void PressButton() {
        if (!isPressed) {
            isPressed = true;
            Debug.Log("Button was pressed");
        }
    }
}
