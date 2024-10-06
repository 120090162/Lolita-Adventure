using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level0_apple : MonoBehaviour
{
    public Vector3 ApplePositon;
    
    void Start()
    {
        ApplePositon = transform.position;
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
