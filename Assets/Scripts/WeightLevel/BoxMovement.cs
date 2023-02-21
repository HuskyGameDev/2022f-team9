using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int waypointIndex = 0;

    [SerializeField] private float speed = 2f;

    void Update()
    {

        if (Vector2.Distance(waypoints[0].transform.position, transform.position) > .01f)
        {
            if (Vector2.Distance(waypoints[1].transform.position, transform.position) > .01f)
            {
                movement();
            }
        }

    }

    public void movement()
    {

        if (Vector2.Distance(waypoints[waypointIndex].transform.position, transform.position) < .01f)
        {

            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {

                waypointIndex = 0;

            }

        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);

    }
}
