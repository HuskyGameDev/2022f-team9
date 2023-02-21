using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLevelController : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("successful entry");
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Laser"))
        {
            platform.SetActive(true);
            Debug.Log("triggered");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("successful exit");
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Laser"))
        {
            platform.SetActive(false);
            Debug.Log("exited");
        }
    }
}
