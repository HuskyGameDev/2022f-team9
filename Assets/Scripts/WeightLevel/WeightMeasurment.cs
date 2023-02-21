using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightMeasurment : MonoBehaviour
{

    int totalWeight;
    [SerializeField] private GameObject[] boxes;

    // Start is called before the first frame update
    void Start()
    {
        
        totalWeight = 0;

    }

    // Update is called once per frame
    void Update()
    {

        int tempWeight = 0;



        if(tempWeight != totalWeight)
        {
            totalWeight = tempWeight;
        }

    }
}
