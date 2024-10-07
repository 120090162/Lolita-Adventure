using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed = 10.0f;
    private Camera mainCamera;
    public Camera overheadCamera;
    public TextMeshProUGUI scoreText;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        scoreText.text = "Steps: " + (400 - GameManager.steps);
        if (GameManager.is_enter && Input.GetKeyDown(KeyCode.Space))
        {
            overheadCamera.enabled = false;
            mainCamera.enabled = true;
            mainCamera.transform.DOMove(GameManager.camera_pos, 0.5f);
        }
        
        if(GameManager.is_level_over || GameManager.steps >= 400)
        {
            GameManager.steps = 0;
            GameManager.is_enter = false;
            GameManager.is_level_over = false;
            GameManager.Level++;
            overheadCamera.enabled = false;
            mainCamera.enabled = true;
            GameManager.is_enter = false;
            mainCamera.transform.DOMove(GameManager.camera_pos, 0.5f).OnComplete((() =>
            {
                mainCamera.transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() =>
                {
                    // 在旋转完成后向前移动5个单位
                    mainCamera.transform.DOMove(mainCamera.transform.position + mainCamera.transform.forward * 10f, 1.5f).OnComplete(() =>
                    {
                        // 相机向左旋转90度，并使用DOTween实现平滑旋转效果
                        mainCamera.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
                        audioSource.Stop();
                    });
                    audioSource.Play();
                });
            }));
        }
    }
}
