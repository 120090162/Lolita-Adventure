using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageDisplayManager : MonoBehaviour
{
    public Image[] images;  // �洢����ͼƬ������
    public float displayTime = 2f;  // ÿ��ͼƬչʾ��ʱ�䣨�룩
    public string nextSceneName;  // �����ת�ĳ�������

    private int currentImageIndex = 0;

    private void Start()
    {
        // ȷ������ͼƬ�ʼ������״̬
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        // ����չʾͼƬ��Э��
        StartCoroutine(DisplayImages());
    }

    private IEnumerator DisplayImages()
    {
        // ������ʾͼƬ
        for (int i = 0; i < images.Length; i++)
        {
            currentImageIndex = i;

            // ��ʾ��ǰͼƬ
            images[currentImageIndex].gameObject.SetActive(true);

            // ���ֵ�ǰͼƬչʾ��ʱ��
            yield return new WaitForSeconds(displayTime);
        }

        // ���һ��ͼƬչʾ�󣬵ȴ�����
        yield return new WaitForSeconds(2f);

        // ��ת����һ������
        SceneManager.LoadScene(2);
    }
}
