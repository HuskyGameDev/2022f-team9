using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    //will have enter and exit collision methods that change status
    //also have get method for that status, most likely just bool of if box is colliding or not
    //these will be used as objects in array for platform and will be used to calculate total weight

    public bool boxCollision;

    // Start is called before the first frame update
    void Start()
    {

        boxCollision = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
