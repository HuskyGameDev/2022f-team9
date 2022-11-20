using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLevelController : MonoBehaviour
{
    //code for spring bouncing
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Spring engaged");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jumped off spring");
            }
        }
    }
}
