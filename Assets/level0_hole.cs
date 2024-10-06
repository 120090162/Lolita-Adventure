using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level0_hole : MonoBehaviour
{
    public Vector3 HolePositon;
    
    void Start()
    {
        HolePositon = transform.position;   
    }

    void OnCollisionEnter2D()
    {
        ;
    }
}
