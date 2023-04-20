using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreenAnimation : MonoBehaviour
{
    public GameObject animationTrigger;
    public Animator anim;
    void Update()
    {
        if (animationTrigger.activeInHierarchy)
        {
            anim.SetBool("active", true);
        }
    }
}
