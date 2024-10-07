using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverScene : MonoBehaviour
{
    public GameObject Camera_1;
    public GameObject Camera_2;
    public GameObject nextScene;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera_1.SetActive(false);
            Camera_2.SetActive(true);
            nextScene.SetActive(true);
        }
    }
}
