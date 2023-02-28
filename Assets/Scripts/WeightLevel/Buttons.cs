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
    //Possibly remove debug.Log statments when done

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAct.Invoke();
                Debug.Log("Interact button was pressed");

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            //Debug.Log("Player is not in range");
        }
    }
}
