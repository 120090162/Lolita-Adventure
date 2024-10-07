using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class HelpMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject playButton;
    public GameObject pauseButton;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        DOTween.PlayAll();
        pauseMenuUI.SetActive(false);
        GameManager.GameIsPaused = false;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Pause()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        GameManager.GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        DOTween.PauseAll();
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

