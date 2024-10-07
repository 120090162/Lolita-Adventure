using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_kite : MonoBehaviour
{
    public Vector3 KitePositon;
    
    void Start()
    {
        KitePositon = transform.position;
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
