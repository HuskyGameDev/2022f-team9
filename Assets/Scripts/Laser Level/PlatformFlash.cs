using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFlash : MonoBehaviour
{

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
    
}
