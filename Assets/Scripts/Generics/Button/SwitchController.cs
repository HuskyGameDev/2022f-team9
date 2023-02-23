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
        
        else if (isSwitched)
        {
            isSwitched = false;
            Debug.Log("Button was pressed again");
            gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
        }
    }
    
        private void reset()
        {
            isSwitched = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
        }
    }
