using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject bs;
    // Start is called before the first frame update
    public void PlayGame() { 
        // Debug.Log("playGame!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        bs.SetActive(true);
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
