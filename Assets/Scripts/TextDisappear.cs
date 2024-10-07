using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisappear : MonoBehaviour
{
    public TMP_Text text;
    public float displayDuration = 15f;  // 文本显示的时长

    void Start()
    {
        text.gameObject.SetActive(true);
        // 开始计时，让文本在 displayDuration 秒后自动消失
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {

        yield return new WaitForSeconds(displayDuration);

        text.gameObject.SetActive(false);
    }
}
