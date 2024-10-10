using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageDisplayManager : MonoBehaviour
{
    public Image[] images;  // 存储所有图片的数组
    public float displayTime = 2f;  // 每张图片展示的时间（秒）
    public string nextSceneName;  // 最后跳转的场景名称

    private int currentImageIndex = 0;

    private void Start()
    {
        // 确保所有图片最开始是隐藏状态
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        // 启动展示图片的协程
        StartCoroutine(DisplayImages());
    }

    private IEnumerator DisplayImages()
    {
        // 逐张显示图片
        for (int i = 0; i < images.Length; i++)
        {
            currentImageIndex = i;

            // 显示当前图片
            images[currentImageIndex].gameObject.SetActive(true);

            // 保持当前图片展示的时间
            yield return new WaitForSeconds(displayTime);
        }

        // 最后一张图片展示后，等待两秒
        yield return new WaitForSeconds(2f);

        // 跳转到下一个场景
        SceneManager.LoadScene(2);
    }
}
