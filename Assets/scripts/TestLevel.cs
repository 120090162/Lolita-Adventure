using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            Debug.Log("Enter Game");
            GameManager.is_enter = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Level++;
            Debug.Log("Level: " + GameManager.Level);
        }
    }
}
