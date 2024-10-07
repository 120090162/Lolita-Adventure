using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisappear : MonoBehaviour
{
    public TMP_Text text;
    public float displayDuration = 15f;  // �ı���ʾ��ʱ��

    void Start()
    {
        text.gameObject.SetActive(true);
        // ��ʼ��ʱ�����ı��� displayDuration ����Զ���ʧ
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {

        yield return new WaitForSeconds(displayDuration);

        text.gameObject.SetActive(false);
    }
}
