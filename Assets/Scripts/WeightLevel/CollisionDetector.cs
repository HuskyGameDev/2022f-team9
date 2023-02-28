using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    //true if the box is on the platform
    public bool boxCollision;

    // Start is called before the first frame update
    void Start()
    {

        boxCollision = false;

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Box"))
        {
            boxCollision = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Box"))
        {
            boxCollision = false;
        }

    }

    //just for getting weight measurment
    public bool getIfColl()
    {

        return boxCollision;

    }
}
