using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Requirementapear1 : MonoBehaviour
{
    public TMP_Text text;
    public float displayDuration = 15f;  // �ı���ʾ��ʱ��

    void Start()
    {
        text.gameObject.SetActive(false);
        // ��ʼ��ʱ�����ı��� displayDuration ����Զ���ʧ
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {

        yield return new WaitForSeconds(displayDuration);

        text.gameObject.SetActive(true);
    }
}
