using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public Transform position1, position2;
    public float speed;
    public Transform startPos;

    [SerializeField] GameObject button;
    [SerializeField] GameObject laser;
    public SwitchController switchController;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        // Find the GameObject with the ButtonController script and get a reference to it
        GameObject buttonControllerObject = GameObject.Find("Button");
        switchController = buttonControllerObject.GetComponent<SwitchController>();

        nextPos = startPos.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (!switchController.isSwitched)
        {
            if (transform.position == position1.position)
            {
                nextPos = position2.position;
            }
            if (transform.position == position2.position)
            {
                nextPos = position1.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}


