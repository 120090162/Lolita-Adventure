using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class level0_hole : MonoBehaviour
{
    public Vector3 HolePositon;
    private bool isFlag = true;
    void Start()
    {
        HolePositon = transform.position;   
    }
    // void Update()
    // {
    //     if ((is_level_over == true) && GameManager.picture.SequenceEqual(GameManager.target_picture))
    //     {
    //         GameManager.is_level_over = true;
    //     }
    // }
    void OnCollisionStay2D()
    {
        if (isFlag)
        {
            if (GameManager.picture.SequenceEqual(GameManager.target_picture))
            {
                GameManager.score++;
            }
            GameManager.is_level_over = true;
            isFlag = false;
        }
    }
}
