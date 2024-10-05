using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureEnter : MonoBehaviour
{
    public ExButton exButton;
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    // Start is called before the first frame update
    void Start()
    {
        exButton.OnDoubleClick = onDoubleClick;
    }
    
    void Update()
    {
        // 检测键盘输入，这里以按下空格键（KeyCode.Space）为例
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstPersonCamera.enabled = true;
            overheadCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void onDoubleClick()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }
}
