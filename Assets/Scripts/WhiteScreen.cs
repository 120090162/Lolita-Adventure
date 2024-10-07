using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhiteScreen : MonoBehaviour
{
    public RawImage spriteRenderer; // 覆盖屏幕的一张全白图片
    public AnimationCurve curve; // 在Inspector上调整自己喜欢的曲线
    [Range(0.5f, 2f)] public float speed = 1f; // 控制渐入渐出的速度

    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    Color tmpColor; // 用于传递颜色的变量

    public IEnumerator FadeOut()
    {
        float timer = 0f;
        tmpColor = spriteRenderer.color;
        tmpColor.a = 1f; // 设置初始透明度为1，即全白

        do
        {
            timer += Time.deltaTime;
            SetColorAlpha(curve.Evaluate(timer * speed)); // 从白色逐渐变为透明
            yield return null;

        } while (tmpColor.a > 0);
        spriteRenderer.enabled = false; // 关闭全白图片
        // 可以在这里执行进入场景后的其他逻辑
    }

    void SetColorAlpha(float a)
    {
        tmpColor.a = a;
        spriteRenderer.color = tmpColor;
    }
}