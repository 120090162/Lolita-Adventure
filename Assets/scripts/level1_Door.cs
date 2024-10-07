using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class level1_Door : MonoBehaviour
{
    public Vector3 DoorPositon;
    private bool is_level_over = false;


    
    void Start()
    {
        DoorPositon = transform.position;
    }

    
    void Update()
    {
        if ((is_level_over == true) && GameManager.picture.SequenceEqual(GameManager.target_picture))
        {
            GameManager.is_level_over = true;
        }
    }

    void OnCollisionEnter2D()
    {
        is_level_over = true;
        // Destroy(gameObject);
    }
    
    void OnCollisionExit2D()
    {
        is_level_over = false;
    }
}
