using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightMeasurment : MonoBehaviour
{
    //can probably repurpose this for waypoints since no longer needed
    [SerializeField] private GameObject[] weightWaypoints;
    //[SerializeField] private float speed = 2f;
    //the total weight that is calculated
    public int totalWeight;

    //Each collider for each box
    public CollisionDetector det1;
    public CollisionDetector det2;
    public CollisionDetector det3;
    public CollisionDetector det4;
    
    // Start is called before the first frame update
    void Start()
    {
        
        totalWeight = 0;

    }

    // Update is called once per frame
    void Update()
    {

        CalculateWeight();

        //After this move the platform based on the totalWeight

    }

    void CalculateWeight()
    {

        int tempWeight = 0;

        if (det1.getIfColl())
        {
            tempWeight = tempWeight + 6;
        }
        if (det2.getIfColl())
        {
            tempWeight = tempWeight + 2;
        }
        if (det3.getIfColl())
        {
            tempWeight = tempWeight + 13;
        }
        if (det4.getIfColl())
        {
            tempWeight = tempWeight + 7;
        }

        if (tempWeight != totalWeight)
        {
            totalWeight = tempWeight;
        }

    }

    void BridgeMovement()
    {

        //code for moving bridge here
        //look at notecards for code

    }
}
