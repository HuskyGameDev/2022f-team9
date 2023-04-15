using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightMeasurment : MonoBehaviour
{
    //Array of all possible locations for the bridge
    [SerializeField] private GameObject[] weightWaypoints;

    //Gate that blocks the player if the total weight is not correct
    //Prevents the player from becoming stuck
    [SerializeField] private GameObject[] gateWaypoints;
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject gateCollision;

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

        //Moves the gate to allow the player to move on at the correct time
        GateMovement();

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

    //Moves the gate at the right time
    void GateMovement()
    {
        //Determines if bridge is close enough to correct position to lower gate
        float yPos = transform.position.y - weightWaypoints[5].transform.position.y;

        if (totalWeight == 9 && (yPos < 0.1f && yPos > -0.1f))
        {
            gate.transform.position = Vector2.MoveTowards(gate.transform.position, gateWaypoints[1].transform.position, Time.deltaTime * speed);
            gateCollision.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            gate.transform.position = Vector2.MoveTowards(gate.transform.position, gateWaypoints[0].transform.position, Time.deltaTime * speed);
            gateCollision.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

}
