using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool isSwitched;
    public Sprite OffSprite;
    public Sprite OnSprite;
    public KeyCode interactKey;
    public PlayerInv playerInv;

    public void PressButton()
    {
        if (!isSwitched)
        {
            isSwitched = true;
            Debug.Log("Button was pressed");
            gameObject.GetComponent<SpriteRenderer>().sprite = OnSprite;
        }
        if (isSwitched)
        {
            isSwitched = false;
            Debug.Log("Button was pressed again");
            gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
        }
    }
    /**
    void Start()
    {
        // Find the GameObject with the ButtonController script and get a reference to it
        GameObject playerControllerObject = GameObject.Find("Player");
        playerInv = playerControllerObject.GetComponent<PlayerInv>();
        Debug.Log("Found Player Inv");
    }

        private void Update()
    {
        if (playerInv.isInRange)
        {
            Debug.Log("In Range");
            if (Input.GetKeyDown(interactKey))
            {
                PressButton();
                Debug.Log("Button Pressed");
            }
        }
    }**/
        private void reset()
        {
            isSwitched = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
        }
    }
