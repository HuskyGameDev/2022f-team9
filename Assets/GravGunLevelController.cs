using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGunLevelController : MonoBehaviour {

    //[SerializeField] GameObject player;
    //private GravGunController gravGunController;
    
    [Header("Buttons and Button Controllers")]
    [SerializeField] GameObject resetBoxes;
    private GenericButtonController resetBoxesController;
    [SerializeField] GameObject resetSprites;
    //private

    [Header("Boxes")]
    [SerializeField] GameObject box0;
    Vector3 box0DefaultPos;
    [SerializeField] GameObject box1;
    Vector3 box1DefaultPos;
    [SerializeField] GameObject box2;
    Vector3 box2DefaultPos;


    private void Start() {
        //gravGunController = player.GetComponent<GravGunController>();
        resetBoxesController = resetBoxes.GetComponent<GenericButtonController>();
        box0DefaultPos = box0.transform.position;
        box1DefaultPos = box1.transform.position;
        box2DefaultPos = box2.transform.position;
    }


    private bool hasRun;

    private void Update() {
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        /*if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 2.85f) {
            gravGunController.current = null;
            gravGunController.currentBody = null;
            gravGunController.objState(false);
        }*/
        if (!hasRun && resetBoxesController.isPressed) {
            hasRun = true;
            resetBoxPos();
            Debug.Log("Ran once!");
        } 
        else if (hasRun && !resetBoxesController.isPressed) {
            hasRun = false;
        }
    }

    private void resetBoxPos() {
        box0.transform.position = box0DefaultPos;
        box1.transform.position = box1DefaultPos;
        box2.transform.position = box2DefaultPos;
    }
}
