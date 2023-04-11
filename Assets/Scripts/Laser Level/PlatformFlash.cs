using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFlash : MonoBehaviour
{
    /*
    [SerializeField] private float flashInterval;
    [SerializeField] private float buffer;
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject platform2;
    [SerializeField] GameObject platform3;
    [SerializeField] GameObject platform4;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(buffer);
        while (true)
        {
            platform1.SetActive(true);
            platform2.SetActive(true);
            platform3.SetActive(true);
            platform4.SetActive(true);
            yield return new WaitForSeconds(flashInterval);
            platform1.SetActive(false);
            platform2.SetActive(false);
            platform3.SetActive(false);
            platform4.SetActive(false);
            yield return new WaitForSeconds(flashInterval);
        }
    }
    */
        [SerializeField] private float flashInterval;
        [SerializeField] private float buffer;
        [SerializeField] private GameObject[] platforms;

        private SpriteRenderer[] spriteRenderers;
        private BoxCollider2D[] boxColliders;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(buffer);

        int[] visiblePlatforms = GetNextPlatforms(0, 4);
        int[] hiddenPlatforms = GetNextPlatforms(4, 4);

        while (true)
        {
            // Show the visible platforms and hide the hidden platforms
            foreach (int i in visiblePlatforms)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = Color.white;
                platforms[i].GetComponent<BoxCollider2D>().enabled = true;
            }
            foreach (int i in hiddenPlatforms)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
                platforms[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            yield return new WaitForSeconds(flashInterval);

            // Show the hidden platforms and hide the visible platforms
            foreach (int i in visiblePlatforms)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
                platforms[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            foreach (int i in hiddenPlatforms)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = Color.white;
                platforms[i].GetComponent<BoxCollider2D>().enabled = true;
            }

            yield return new WaitForSeconds(flashInterval);

            // Cycle to the next set of visible and hidden platforms
            visiblePlatforms = GetNextPlatforms((visiblePlatforms[0] + 4) % platforms.Length, 4);
            hiddenPlatforms = GetNextPlatforms((hiddenPlatforms[0] + 4) % platforms.Length, 4);
        }
    }


    private int[] GetNextPlatforms(int startIndex, int count)
    {
        int[] indices = new int[count];
        for (int i = 0; i < count; i++)
        {
            indices[i] = (startIndex + i) % platforms.Length;
        }
        return indices;
    }
}

