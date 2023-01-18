using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    [SerializeField] GameObject four;
    [SerializeField] GameObject three;
    [SerializeField] GameObject two;
    [SerializeField] GameObject one;
    
    public int collisionCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            collisionCounter++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            collisionCounter--;
        }
    }
    private void Update()
    {
        if (collisionCounter == 0)
        {
            four.SetActive(true);
            three.SetActive(false);
            two.SetActive(false);
            one.SetActive(false);
        }
        else if (collisionCounter == 1)
        {
            four.SetActive(false);
            three.SetActive(true);
            two.SetActive(false);
            one.SetActive(false);
        }
        else if (collisionCounter == 2)
        {
            four.SetActive(false);
            three.SetActive(false);
            two.SetActive(true);
            one.SetActive(false);
        }
        else if (collisionCounter == 3)
        {
            four.SetActive(false);
            three.SetActive(false);
            two.SetActive(false);
            one.SetActive(true);
        }
        else if (collisionCounter == 4)
        {
            four.SetActive(false);
            three.SetActive(false);
            two.SetActive(false);
            one.SetActive(false);
        }
    }

}