using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4_star : MonoBehaviour
{
    public Vector3 StarPositon;
    
    void Start()
    {
        StarPositon = transform.position;
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
