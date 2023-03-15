using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    [SerializeField] GameObject fourRed;
    [SerializeField] GameObject threeRed;
    [SerializeField] GameObject twoRed;
    [SerializeField] GameObject oneRed;

    [SerializeField] GameObject fourGreen;
    [SerializeField] GameObject threeGreen;
    [SerializeField] GameObject twoGreen;
    [SerializeField] GameObject oneGreen;

    [SerializeField] GameObject key;
    [SerializeField] GameObject platform;

    public int collisionCounter;
    public bool keySpawned = false;

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
    private void spawnKey()
    {
        if (keySpawned == false)
        {
            key.SetActive(true);
            platform.SetActive(true);
            keySpawned = true;
        }
    }
    private void Update()
    {
        if (collisionCounter == 0)
        {
            fourRed.SetActive(true);
            threeRed.SetActive(true);
            twoRed.SetActive(true);
            oneRed.SetActive(true);

            fourGreen.SetActive(false);
            threeGreen.SetActive(false);
            twoGreen.SetActive(false);
            oneGreen.SetActive(false);
        }
        else if (collisionCounter == 1)
        {
            fourRed.SetActive(false);
            threeRed.SetActive(true);
            twoRed.SetActive(true);
            oneRed.SetActive(true);

            fourGreen.SetActive(true);
            threeGreen.SetActive(false);
            twoGreen.SetActive(false);
            oneGreen.SetActive(false);
        }
        else if (collisionCounter == 2)
        {
            fourRed.SetActive(false);
            threeRed.SetActive(false);
            twoRed.SetActive(true);
            oneRed.SetActive(true);

            fourGreen.SetActive(true);
            threeGreen.SetActive(true);
            twoGreen.SetActive(false);
            oneGreen.SetActive(false);
        }
        else if (collisionCounter == 3)
        {
            fourRed.SetActive(false);
            threeRed.SetActive(false);
            twoRed.SetActive(false);
            oneRed.SetActive(true);

            fourGreen.SetActive(true);
            threeGreen.SetActive(true);
            twoGreen.SetActive(true);
            oneGreen.SetActive(false);
        }
        else if (collisionCounter == 4)
        {
            fourRed.SetActive(false);
            threeRed.SetActive(false);
            twoRed.SetActive(false);
            oneRed.SetActive(false);

            fourGreen.SetActive(true);
            threeGreen.SetActive(true);
            twoGreen.SetActive(true);
            oneGreen.SetActive(true);

            spawnKey();
        }
        else if (keySpawned == true)
        {
            fourRed.SetActive(false);
            threeRed.SetActive(false);
            twoRed.SetActive(false);
            oneRed.SetActive(false);

            fourGreen.SetActive(true);
            threeGreen.SetActive(true);
            twoGreen.SetActive(true);
            oneGreen.SetActive(true);
        }
    }

}
