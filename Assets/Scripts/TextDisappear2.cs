using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class TextDisappear2 : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text pre_text;
    public TMP_Text next_text;
    public float displayDuration1 = 5f;  // 文本显示的时长
    public float displayDuration2 = 5f;
    private bool is_finish = false;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
        next_text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.picture.SequenceEqual(GameManager.target_picture) && is_finish == false) {
            is_finish = true;
            pre_text.gameObject.SetActive(false);
            text.gameObject.SetActive(true);
            // 开始计时，让文本在 displayDuration 秒后自动消失
            StartCoroutine(HideTextAfterDelay());
        }
    }
    IEnumerator HideTextAfterDelay()
    {

        yield return new WaitForSeconds(displayDuration1);

        text.gameObject.SetActive(false);
        next_text.gameObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay1());
    }

    IEnumerator HideTextAfterDelay1()
    {

        yield return new WaitForSeconds(displayDuration2);

        next_text.gameObject.SetActive(false);
    }
}
