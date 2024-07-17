using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private Animator anim;
    public bool crahsed;

    void Start()
    {
        
    }

    void Update()
    {
        if (crahsed == true)
        {
            GetComponent<Animator>().SetTrigger("TrCameraCrash");           
        }
    }
}
