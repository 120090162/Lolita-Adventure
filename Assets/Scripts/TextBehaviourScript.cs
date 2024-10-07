using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextBehaviourScript : MonoBehaviour
{

        // �����ı�
        private readonly string text_test = "SVN������Ҫά���Ķ���Scene; Scripts/Engine/WSC SteamingAsset/2DPivots.json Editor/WSCPivotEditor.cs \n �·���ʾ";

        [Header("�ı���ʾ"), Space(10)]
        public float typingSpeed = 0.2f; // �����ٶ�
        public int rowShowMax = 25; // һ�������ʾ����
        public int allowRedundancy = 6; // �������������
        public bool isUpdateText = false; // �Ƿ񲥷�

        public Text text; // �ײ���Ļ

        [Range(-25, 25), Space(5)]
        public int offsetY = -3; // ��һ��Y�Ჹ��
        public Vector3 saveMarqueeOriginPostion = new Vector3(0, -63, 0); // �·���Ļ��ԭ��λ��

        private float textTimeCount = 0; // �����õļ�ʱ��
        private string word = ""; //������Ļ
        private int currentPos = 0; // �����ַ�����
        private int LineBreakCount = 0; // ���з�����

        private Vector3 saveTextLocatePostion;  // ���ڱ���TextUIλ��

        private bool isOriginPosition = true;

        void Update()
        {
            UpdateText();
            /*if (Input.GetMouseButtonDown(0))
            {
                OnTextUpdate(text_test);
            }*/
        }

        // �ı�����
        private void UpdateText()
        {
            if (!isUpdateText)
            {
                return;
            }

            // �����Ļ�Ƿ�λ��ԭ��λ��
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
                    Debug.Log("�������");

                    OnFinish();
                    return;
                }
                text.text = word[..currentPos];//ˢ���ı���ʾ����
                if (word[currentPos - 1] == '\n')
                {
                    Debug.Log("���ֻ��з�");
                    LineBreakCount++;

                    // ÿ������һ�����з�������25����λ
                    if (LineBreakCount == 1)
                    {
                        text.rectTransform.DOLocalMoveY(text.rectTransform.localPosition.y + 25 + offsetY, 1f);
                    }
                    else if (LineBreakCount != 1)
                    {
                        text.rectTransform.DOLocalMoveY(text.rectTransform.localPosition.y + 25, 1f);
                    }

                }

                // ÿ�δ����г���
                int lineCount;
                if (LineBreakCount == 0)
                {
                    lineCount = text.text.Length;
                }
                else
                {
                    lineCount = text.text[text.text.LastIndexOf('\n')..].Length;
                }

                // �г���
                if (lineCount > rowShowMax + allowRedundancy)
                {
                    word = text.text + '\n' + word[text.text.Length..];
                }

            }
        }

        [Header("�·���ʾ�ӳ���ʧ������Ҫ��ʱ��")]
        public float textCloseDelayTime = 2.0f;

        /// <summary>
        /// �·���ʾ��Ϸ����,��ʹ��ǰԤ����
        /// </summary>
        public GameObject BottomShow;

        public IEnumerator IE_TextCloseDelayTime(float time)
        {
            yield return new WaitForSeconds(time);
            BottomShow.SetActive(false);
            Debug.Log("�·���ʾ�ѹر�");
        }

        public IEnumerator IE_OnTextReset(float time)
        {
            yield return new WaitForSeconds(time);
            OnTextReset();
            Debug.Log("�ı��ָ�Ĭ��");
            isOriginPosition = true;
            BottomShow.transform.DOLocalMove(saveMarqueeOriginPostion, 1.0f);
        }

        // �ı�������� , һ��ȷ�ϹرվͲ�Ҫ�ٸ����ı�, ��������߼����������ڲ�����Ϻ�����ı�һ��Ҫ���·���ʾ�رպ�, ��Ļ�ع���ʱ���ܸ����ı�.
        private void OnFinish()
        {
            isUpdateText = false;
            // ���֮���·���ʾ �ӳٹر�, λ�ûص�
            // StartCoroutine(IE_TextCloseDelayTime(textCloseDelayTime));
            // �ӳ��ı�����λ��
            StartCoroutine(IE_OnTextReset(textCloseDelayTime));
            text.rectTransform.DOLocalMove(saveTextLocatePostion + new Vector3(0, offsetY, 0), textCloseDelayTime);
        }

        // �ı�����, һ�����¾���ȷ��Ҫ��ʼ����(�s�F����)�s��ߩ��ߣ�����²���Ϊ�˲���?��
/*        private void OnTextUpdate(string newtext)
        {

            text = GameObject.Find("��Ļ����").gameObject.GetComponent<Text>();
            OnTextReset();
            word = newtext;
            // StartCoroutine(IE_OnTextReset(0.5f));
            BottomShow.SetActive(true);
            isUpdateText = true;
        }*/

        // �ı��֏�Ĭ��: ����Ϊ0, ���з�ͳ��Ϊ0, LocalPostion�ָ�, �ı��ÿ�
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

        // ��ʼ��
        public void Init()
        {
            Debug.Log("�ı����³�ʼ�����");
        }

        public void UnInit()
        {
            Debug.Log("�ı����ƽ���");
        }
        private void OnDestroy()
        {
            UnInit();
        }
    }


