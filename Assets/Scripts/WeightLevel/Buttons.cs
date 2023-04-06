using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buttons : MonoBehaviour
{
    //true if player is in range, false otherwise
    public bool isInRange;
    //key the player has to press to press the button
    public KeyCode interactKey;
    //the action that the button performs
    public UnityEvent interactAct;
    public Sprite on;
    public Sprite off;
    public bool isPressed;

    // Update is called once per frame
    void Update()
    {

        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey) && !isPressed)
            {
                isPressed = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = on;
                interactAct.Invoke();
                StartCoroutine(delayReset());
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void reset()
    {
        isPressed = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = off;
    }

    IEnumerator delayReset()
    {
        yield return new WaitForSecondsRealtime(1f);
        reset();
    }
}
