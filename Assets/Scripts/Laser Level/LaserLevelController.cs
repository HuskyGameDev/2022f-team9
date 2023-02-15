using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLevelController : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            platform.SetActive(true);
        }

    }
}
