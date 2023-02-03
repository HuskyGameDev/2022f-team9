using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour {


    const int NO_OBJ = 1;
    const int HAS_OBJ = 2;

    public Sprite noObj;
    public Sprite hasObj;
    [SerializeField] public SpriteRenderer currentSprite;

    public void changeOutline(int STATUS) {
        switch (STATUS) {
            case NO_OBJ:
                Debug.Log("no obj");
                currentSprite.sprite = noObj;
                break;

            case HAS_OBJ:
                Debug.Log("has obj");
                currentSprite.sprite = hasObj;
                break;
        }
    }





}
