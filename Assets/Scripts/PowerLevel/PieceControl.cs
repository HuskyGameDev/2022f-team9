using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceControl : MonoBehaviour
{
    [Header("Guide Object")]
    [SerializeField] bool isSolution;
    [SerializeField] bool isSolved;
    [SerializeField] int[] solves = {-1, -1, -1};

    int spun = 0;
    bool incremented = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<2; i++) {
	    if(spun == solves[i]) {

	        isSolved = true;
	    	i = 3;
	    }
	    else {
		isSolved = false;
	    }
	}

	if(isSolution && isSolved && !incremented){    
	    SendMessageUpwards("increase");
	    incremented = true;
	}
	else if(isSolution && !isSolved && incremented){
	    SendMessageUpwards("decrease");
	    incremented = false;
	}

    }

    void OnMouseDown() {

	gameObject.transform.Rotate(new Vector3(0, 0, -90));
	spun++;
	if(spun > 3) spun = 0;

    }
}
