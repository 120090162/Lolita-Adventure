using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level0_apple : MonoBehaviour
{
    public Vector3 ApplePositon;
    public GameObject lightApparent;
    
    void Start()
    {
        ApplePositon = transform.position;
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
        lightApparent.SetActive(true);
        // Debug.Log("Apple is eaten");
    }
}
