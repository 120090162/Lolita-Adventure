using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_Door : MonoBehaviour
{
    public Vector3 DoorPositon;
    
    void Start()
    {
        DoorPositon = transform.position;
    }

    void OnCollisionEnter2D()
    {
        Debug.Log("You Pass Level 1 !");
        GameManager.is_game_over = true;
    }
}
