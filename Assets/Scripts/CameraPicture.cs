using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPicture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
