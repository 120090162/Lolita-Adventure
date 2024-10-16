using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PictureEnter : MonoBehaviour
{
    public ExButton exButton;
    public Camera mainCamera;
    public Camera overheadCamera;
    public Camera picCamera;
    public Transform sphere;
    public PuzzleChange puzzleChange;
    private Texture2D screenShot;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        exButton.OnDoubleClick = onDoubleClick;
        // exButton.OnClick = onClick;
    }
    
    void Update()
    {
        if (GameManager.Level != 4)
        {
            // 检测键盘输入，这里以按下空格键（KeyCode.Space）为例
            if (GameManager.is_level_over || Input.GetKeyDown(KeyCode.F))
            {
                Rect viewportRect = picCamera.rect;
                Rect captureRect = new Rect(viewportRect.x * Screen.width, viewportRect.y * Screen.height, viewportRect.width * Screen.width, viewportRect.height * Screen.height);
                screenShot = CaptureCamera(picCamera, captureRect);
                Sprite sprite = Sprite.Create(screenShot, new Rect(0, 0, screenShot.width, screenShot.height), Vector2.zero);
                image.sprite = sprite;
            }
        }
    }
    
    /// <summary>
    /// 对相机截图
    /// </summary>
    /// <param name="camera">Camera.要被截屏的相机</param>
    /// <param name="rect">Rect.截屏的区域</param>
    /// <returns>The screenshot2.</returns>
    Texture2D CaptureCamera(Camera camera, Rect rect)
    {
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);//创建一个RenderTexture对象
        camera.targetTexture = rt;//临时设置相关相机的targetTexture为rt, 并手动渲染相关相机
        camera.Render();
        //ps: --- 如果这样加上第二个相机，可以实现只截图某几个指定的相机一起看到的图像。
        //ps: camera2.targetTexture = rt;
        //ps: camera2.Render();
        //ps: -------------------------------------------------------------------

        RenderTexture.active = rt;//激活这个rt, 并从中中读取像素。
        Rect rightHalfRect = new Rect(rect.width / 2, 0, rect.width / 2, rect.height);
        Texture2D screenShot = new Texture2D((int)rightHalfRect.width, (int)rightHalfRect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rightHalfRect, 0, 0);//注：这个时候，它是从RenderTexture.active中读取像素
        screenShot.Apply();

        //重置相关参数，以使用camera继续在屏幕上显示
        camera.targetTexture = null;
        //ps: camera2.targetTexture = null;
        RenderTexture.active = null; //JC: added to avoid errors
        GameObject.Destroy(rt);
        return screenShot;
    }


    // Update is called once per frame
    void onDoubleClick()
    {
        puzzleChange.ChangePuzzle();
        // Debug.Log("List<int>中的所有值: " + string.Join(", ", GameManager.picture));
        CameraFocusAt(sphere, () =>
        {
            mainCamera.enabled = false;
            overheadCamera.enabled = true;
            GameManager.is_enter = true;
        });
    }
    // void onClick()
    // {
    //     CameraFocusAt(sphere);
    // }
    //聚焦对象
    private void CameraFocusAt(Transform target, Action onComplete)
    {
        var cp = CalcScreenCenterPosOnPanel();
        var tp = target.position;
        //1.直接移动
        // mainCamera.transform.Translate(tp - cp,Space.World);
        //2.使用tween移动
        mainCamera.transform.DOMove(tp - cp, 0.2f).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }
 
 
    /// <summary>
    /// 屏幕中心点到panel上的坐标
    /// </summary>
    /// <returns></returns>
    private Vector3 CalcScreenCenterPosOnPanel()
    {
        return mainCamera.ScreenPointToRay(Input.mousePosition).direction.normalized;
    }
}
