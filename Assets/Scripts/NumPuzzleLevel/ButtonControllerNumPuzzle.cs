using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerNumPuzzle : MonoBehaviour
{
    public GameObject wallToScale;

    private bool isPlayerNearby = false;

    public PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            playerMovement.runSpeed = 0;
            Debug.Log("button pressed");
           
            wallToScale.SetActive(false);
            
        }
    }
}
