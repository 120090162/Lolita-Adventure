using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public void Pause()
    {
        Time.timeScale = 0f;
        DOTween.PauseAll();
    }
}
