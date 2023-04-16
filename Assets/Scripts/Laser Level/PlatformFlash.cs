using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFlash : MonoBehaviour
{
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

                SpriteRenderer[] renderers = platforms[i].GetComponentsInChildren<SpriteRenderer>();

                for (int x = 0; x < renderers.Length; x++)
                {
                    renderers[x].color = Color.white;
                }
            }
            foreach (int i in hiddenPlatforms)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
                platforms[i].GetComponent<BoxCollider2D>().enabled = false;

                SpriteRenderer[] renderers = platforms[i].GetComponentsInChildren<SpriteRenderer>();

                for (int x = 0; x < renderers.Length; x++)
                {
                    renderers[x].color = new Color(1f, 1f, 1f, 0.1f);
                }
            }

            yield return new WaitForSeconds(flashInterval);

            // Show the hidden platforms and hide the visible platforms
            foreach (int i in visiblePlatforms)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
                platforms[i].GetComponent<BoxCollider2D>().enabled = false;

                SpriteRenderer[] renderers = platforms[i].GetComponentsInChildren<SpriteRenderer>();

                for (int x = 0; x < renderers.Length; x++)
                {
                    renderers[x].color = new Color(1f, 1f, 1f, 0.1f);
                }
            }
            foreach (int i in hiddenPlatforms)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = Color.white;
                platforms[i].GetComponent<BoxCollider2D>().enabled = true;

                SpriteRenderer[] renderers = platforms[i].GetComponentsInChildren<SpriteRenderer>();

                for (int x = 0; x < renderers.Length; x++)
                {
                    renderers[x].color = Color.white;
                }
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

