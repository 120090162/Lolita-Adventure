using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class level1_Door : MonoBehaviour
{
    public Vector3 DoorPositon;


    
    void Start()
    {
        DoorPositon = transform.position;
    }

    
    // void Update()
    // {
    //     if ((is_level_over == true) && GameManager.picture.SequenceEqual(GameManager.target_picture))
    //     {
    //         GameManager.is_level_over = true;
    //     }
    // }

    void OnCollisionEnter2D()
    {
        if (GameManager.picture.SequenceEqual(GameManager.target_picture))
        {
            GameManager.score++;
        }
        GameManager.is_level_over = true;
        // Debug.Log("You Pass Level 0 !");
    }
}
