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
        // wallToScale.SetActive(isActive);
        StartCoroutine(OpenDoor());
        if (isActive)
        {
            playerMovement.runSpeed = 50;
         
        }
    }
    private IEnumerator OpenDoor()
    {
        float duration = 2f; // Time in seconds for the door to open
        float elapsedTime = 0f;
        Vector3 initialScale = wallToScale.transform.localScale;
        Vector3 targetScale = new Vector3(initialScale.x, 0, initialScale.z);

        Vector3 initialPosition = wallToScale.transform.position;
        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y - initialScale.y / 2, initialPosition.z);

        while (elapsedTime < duration)
        {
            wallToScale.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            wallToScale.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        wallToScale.transform.localScale = targetScale; // Ensure the final scale is set
        wallToScale.transform.position = targetPosition; // Ensure the final position is set
        wallToScale.SetActive(false); // Hide the wall once the scaling is complete
    }

}
