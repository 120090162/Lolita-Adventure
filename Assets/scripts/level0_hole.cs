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
        GameManager.is_level_over = true;
        Debug.Log("You Pass Level 0 !");
    }
}
