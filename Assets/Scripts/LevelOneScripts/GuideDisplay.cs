using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideDisplay : MonoBehaviour
{

    [Header("Guide Object")]
    [SerializeField] GameObject guide;
    [Header("Transform parameters")]
    [SerializeField] float sizeX;
    [SerializeField] float sizeY;
    [SerializeField] float posX;
    [SerializeField] float posY;

    private bool big = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSize(){
	if(big) {
	    shrink();
	}
	else {
	    grow();
	}
    }

    public void grow() {
	guide.transform.localScale += new Vector3(sizeX, sizeY, 0);
	guide.transform.position += new Vector3(posX, posY, 0);
	guide.GetComponent<SpriteRenderer>().sortingOrder = 1;
	big = true;
    }

    public void shrink() {
	guide.transform.localScale += new Vector3(-sizeX, -sizeY, 0);
	guide.transform.position += new Vector3(-posX, -posY, 0);
	guide.GetComponent<SpriteRenderer>().sortingOrder = -1;
	big = false;
     }
	
}
