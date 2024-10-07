using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Game_Continue : MonoBehaviour
{
    // Start is called before the first frame update
    public void Con()
    {
        Time.timeScale = 1;
        DOTween.PlayAll();
    }
    
}
