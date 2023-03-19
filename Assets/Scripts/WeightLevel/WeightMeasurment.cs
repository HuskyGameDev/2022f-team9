using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightMeasurment : MonoBehaviour
{
    //Array of all possible locations for the bridge
    [SerializeField] private GameObject[] weightWaypoints;
    //How fast the bridge will move
    [SerializeField] private float speed = 2f;
    //The total weight that is calculated
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
        //Calcultes the correct total weight
        CalculateWeight();
        //Moves the bridge based on the total weight
        BridgeMovement();

    }

    //Calculates the correct total weight
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

    //Moves the bridge based on the current total weight
    void BridgeMovement()
    {

        if (totalWeight == 0)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[0].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 2)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[1].transform.position, Time.deltaTime * speed);

        }
        else if (totalWeight == 6)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[2].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 7)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[3].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 8)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[4].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 9)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[5].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 13)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[6].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 15)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[7].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 19)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[8].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 20)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[9].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 21)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[10].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 22)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[11].transform.position, Time.deltaTime * speed);

        } else if (totalWeight == 26)
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[12].transform.position, Time.deltaTime * speed);

        } else
        {

            transform.position = Vector2.MoveTowards(transform.position, weightWaypoints[13].transform.position, Time.deltaTime * speed);

        }

    }

}
