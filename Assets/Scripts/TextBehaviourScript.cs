using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextBehaviourScript : MonoBehaviour
{

        // 测试文本
        private readonly string text_test = "SVN中我需要维护的东西Scene; Scripts/Engine/WSC SteamingAsset/2DPivots.json Editor/WSCPivotEditor.cs \n 下方提示";

        [Header("文本显示"), Space(10)]
        public float typingSpeed = 0.2f; // 打字速度
        public int rowShowMax = 25; // 一行最大显示数量
        public int allowRedundancy = 6; // 允许的冗余数量
        public bool isUpdateText = false; // 是否播放

        public Text text; // 底部字幕

        [Range(-25, 25), Space(5)]
        public int offsetY = -3; // 第一行Y轴补偿
        public Vector3 saveMarqueeOriginPostion = new Vector3(0, -63, 0); // 下方字幕的原初位置

        private float textTimeCount = 0; // 更新用的计时器
        private string word = ""; //保存字幕
        private int currentPos = 0; // 打字字符索引
        private int LineBreakCount = 0; // 换行符计数

        private Vector3 saveTextLocatePostion;  // 用于保存TextUI位置

        private bool isOriginPosition = true;

        void Update()
        {
            UpdateText();
            /*if (Input.GetMouseButtonDown(0))
            {
                OnTextUpdate(text_test);
            }*/
        }

        // 文本更新
        private void UpdateText()
        {
            if (!isUpdateText)
            {
                return;
            }

            // 检查字幕是否位于原初位置
            if (isOriginPosition)
            {
                isOriginPosition = !isOriginPosition;
                BottomShow.transform.DOLocalMove(Vector3.zero, 1.0f);
            }

            BottomShow.SetActive(true);

            if (saveTextLocatePostion == Vector3.zero)
            {
                saveTextLocatePostion = text.rectTransform.localPosition;
            }

            //if (word == "")
            //{
            //    word = text.text;
            //}

            word = text.text;

            textTimeCount += Time.deltaTime;
            if (textTimeCount > typingSpeed)
            {
                textTimeCount = 0;
                currentPos++;
                if (currentPos >= word.Length)
                {
                    Debug.Log("播放完成");

                    OnFinish();
                    return;
                }
                text.text = word[..currentPos];//刷新文本显示内容
                if (word[currentPos - 1] == '\n')
                {
                    Debug.Log("发现换行符");
                    LineBreakCount++;

                    // 每次遇到一个换行符就上移25个单位
                    if (LineBreakCount == 1)
                    {
                        text.rectTransform.DOLocalMoveY(text.rectTransform.localPosition.y + 25 + offsetY, 1f);
                    }
                    else if (LineBreakCount != 1)
                    {
                        text.rectTransform.DOLocalMoveY(text.rectTransform.localPosition.y + 25, 1f);
                    }

                }

                // 每次处理行超限
                int lineCount;
                if (LineBreakCount == 0)
                {
                    lineCount = text.text.Length;
                }
                else
                {
                    lineCount = text.text[text.text.LastIndexOf('\n')..].Length;
                }

                // 行超限
                if (lineCount > rowShowMax + allowRedundancy)
                {
                    word = text.text + '\n' + word[text.text.Length..];
                }

            }
        }

        [Header("下方显示延迟消失的所需要的时间")]
        public float textCloseDelayTime = 2.0f;

        /// <summary>
        /// 下方提示游戏物体,在使用前预加载
        /// </summary>
        public GameObject BottomShow;

        public IEnumerator IE_TextCloseDelayTime(float time)
        {
            yield return new WaitForSeconds(time);
            BottomShow.SetActive(false);
            Debug.Log("下方显示已关闭");
        }

        public IEnumerator IE_OnTextReset(float time)
        {
            yield return new WaitForSeconds(time);
            OnTextReset();
            Debug.Log("文本恢复默认");
            isOriginPosition = true;
            BottomShow.transform.DOLocalMove(saveMarqueeOriginPostion, 1.0f);
        }

        // 文本更新完成 , 一旦确认关闭就不要再更新文本, 否侧会出现逻辑错误，如若在播放完毕后更新文本一定要在下方显示关闭后, 字幕回滚的时候不能更新文本.
        private void OnFinish()
        {
            isUpdateText = false;
            // 完成之后下方显示 延迟关闭, 位置回调
            // StartCoroutine(IE_TextCloseDelayTime(textCloseDelayTime));
            // 延迟文本重置位置
            StartCoroutine(IE_OnTextReset(textCloseDelayTime));
            text.rectTransform.DOLocalMove(saveTextLocatePostion + new Vector3(0, offsetY, 0), textCloseDelayTime);
        }

        // 文本更新, 一旦更新就是确定要开始播放(╯‵□′)╯︵┻━┻（你更新不是为了播放?）
/*        private void OnTextUpdate(string newtext)
        {

            text = GameObject.Find("字幕文字").gameObject.GetComponent<Text>();
            OnTextReset();
            word = newtext;
            // StartCoroutine(IE_OnTextReset(0.5f));
            BottomShow.SetActive(true);
            isUpdateText = true;
        }*/

        // 文本恢復默认: 索引为0, 换行符统计为0, LocalPostion恢复, 文本置空
        private void OnTextReset()
        {
            if (saveTextLocatePostion == Vector3.zero)
            {
                saveTextLocatePostion = text.rectTransform.localPosition;
            }
            text.rectTransform.localPosition = saveTextLocatePostion;
            text.text = "";
            LineBreakCount = 0;
            currentPos = 0;
        }

        // 初始化
        public void Init()
        {
            Debug.Log("文本更新初始化完成");
        }

        public void UnInit()
        {
            Debug.Log("文本控制结束");
        }
        private void OnDestroy()
        {
            UnInit();
        }
    }


