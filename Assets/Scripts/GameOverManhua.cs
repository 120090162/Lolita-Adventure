using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverManhua : MonoBehaviour
{
    public Image[] images; 
    public float displayTime = 2f; 
    public GameObject Camera_0;  
    public GameObject Camera_1;
    public GameObject nextScene;

    private int currentImageIndex = 0;

    void Start()
    {
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }
        Camera_0.SetActive(true);

        StartCoroutine(DisplayImages());
    }

    private IEnumerator DisplayImages()
    {
        yield return new WaitForSeconds(displayTime);
        
        for (int i = 0; i < images.Length; i++)
        {
            currentImageIndex = i;

            images[currentImageIndex].gameObject.SetActive(true);

            yield return new WaitForSeconds(displayTime);
        }

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        Camera_0.SetActive(false);
        Camera_1.SetActive(true);
        nextScene.SetActive(true);

        // yield return new WaitForSeconds(2f);

        // SceneManager.LoadScene(nextSceneName);
    }
}
