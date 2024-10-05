using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PictureEnter : MonoBehaviour
{
    public ExButton exButton;
    public Camera mainCamera;
    public Camera overheadCamera;
    private Plane _plane;
    public Transform sphere;
    // Start is called before the first frame update
    void Start()
    {
        exButton.OnDoubleClick = onDoubleClick;
        exButton.OnClick = onClick;
        _plane = new Plane(Vector3.up, Vector3.zero);
    }
    
    void Update()
    {
        // 检测键盘输入，这里以按下空格键（KeyCode.Space）为例
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainCamera.enabled = true;
            overheadCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void onDoubleClick()
    {
        mainCamera.enabled = false;
        overheadCamera.enabled = true;
    }
    void onClick()
    {
        CameraFocusAt(sphere);
    }
    //聚焦对象
    private void CameraFocusAt(Transform target)
    {
        var cp = CalcScreenCenterPosOnPanel();
        var tp = target.position;
        //1.直接移动
        // mainCamera.transform.Translate(tp - cp,Space.World);
        //2.使用tween移动
        mainCamera.transform.DOMove(tp - cp, 0.5f);
    }
 
 
    /// <summary>
    /// 屏幕中心点到panel上的坐标
    /// </summary>
    /// <returns></returns>
    private Vector3 CalcScreenCenterPosOnPanel()
    {
        // var ray = mainCamera.ScreenPointToRay(new Vector3((float) Screen.width / 2, (float)Screen.height / 2, 0));
        // if (_plane.Raycast(ray, out var distance))
        // {
        //     return ray.GetPoint(distance);
        // }
        // else
        // {
        //     return Vector3.zero;
        // }
        return mainCamera.ScreenPointToRay(Input.mousePosition).direction;
    }
}
