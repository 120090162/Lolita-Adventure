using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInspector : MonoBehaviour
{
    public List<GameObject> levelpuzzles;
    public List<GameObject> Levels;

    public GameObject player;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    public void SetLastPuzzleFalse()
    {
        levelpuzzles[GameManager.Level-1].SetActive(false);
        Levels[GameManager.Level-1].SetActive(false);
    }
    public void SetCurrentPuzzleTrue()
    {
        levelpuzzles[GameManager.Level].SetActive(true);
        Levels[GameManager.Level].SetActive(true);
        rb.simulated = false;
        player.transform.SetParent(Levels[GameManager.Level].transform);
        player.transform.localPosition = GameManager.player_pos;
        GameManager.SetPlayerId(GameManager.player_pos);
    }
}
