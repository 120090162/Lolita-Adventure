using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class level1_Bone : MonoBehaviour
{
    public Vector3 BonePositon;

    
    void Start()
    {
        BonePositon = transform.position;
    }

    void OnCollisionEnter2D() {
        Destroy(gameObject);
    }

}
