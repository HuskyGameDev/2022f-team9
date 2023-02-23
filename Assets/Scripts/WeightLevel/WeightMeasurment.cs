using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightMeasurment : MonoBehaviour
{

    [SerializeField] private GameObject[] colliders;
    int totalWeight;
    //6,2,13,7
    // Start is called before the first frame update
    void Start()
    {
        
        totalWeight = 0;

    }

    // Update is called once per frame
    void Update()
    {

        int tempWeight = 0;

        //NEEDS TO BE FINISHED
        //if (colliders[0].getIfColl())
        {
            tempWeight = tempWeight + 6;
        }
       // if (colliders[1].getIfColl())
        {
            tempWeight = tempWeight + 2;
        }
        //if (colliders[2].getIfColl())
        {
            tempWeight = tempWeight + 13;
        }
       // if (colliders[3].getIfColl())
        {
            tempWeight = tempWeight + 7;
        }

        if(tempWeight != totalWeight)
        {
            totalWeight = tempWeight;
        }

    }
}
