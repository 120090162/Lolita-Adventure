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
                playButton.SetActive(false);
                pauseButton.SetActive(true);
                Resume();
            }
            else
            {
                playButton.SetActive(true);
                pauseButton.SetActive(false);
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameManager.GameIsPaused = false;
        Time.timeScale = 1f;
        DOTween.PlayAll();
    }

    void Pause()
    {
        Time.timeScale = 0f;
        DOTween.PauseAll();
        GameManager.GameIsPaused = true;
        pauseMenuUI.SetActive(true);

    }

    public void LoadMenu()
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

