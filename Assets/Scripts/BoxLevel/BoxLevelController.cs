using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLevelController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float jumpForce = 13f;
    //code for spring bouncing
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Spring engaged");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
