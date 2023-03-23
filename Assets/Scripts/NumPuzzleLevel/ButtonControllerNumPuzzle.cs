using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerNumPuzzle : MonoBehaviour
{
    public GameObject wallToScale;

    private bool isPlayerNearby = false;

    public PlayerMovement playerMovement;
    public PuzzleScript pS;
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        pS = GetComponent<PuzzleScript>();
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
           // Debug.Log("button pressed");
            if (pS != null)
            {
                pS.ShowBoard(true);
            }
           // wallToScale.SetActive(false);
            
        }
    }

    public void SetWallToScaleActive (bool isActive)
    {
        wallToScale.SetActive(isActive);

        if (isActive)
        {
            playerMovement.runSpeed = 50;
         
        }
    }
}
