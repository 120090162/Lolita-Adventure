using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChange : MonoBehaviour
{
    public GameObject player;
    public GameObject root;
    public List<GameObject> items;
    public List<GameObject> blocks;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    public void ChangePuzzle()
    {
        foreach (var item in items)
        {
            int id = item.GetComponent<ItemPos>().id;
            int pos = GameManager.picture.IndexOf(id);
            if (pos != -1)
            {
                if (id == GameManager.player_id)
                {
                    rb.simulated = false;
                    player.transform.SetParent(item.transform);
                    item.transform.SetParent(blocks[pos].transform);
                    item.transform.position = blocks[pos].transform.position;
                    player.transform.SetParent(root.transform);
                    rb.simulated = true;
                }
                else
                {
                    item.transform.SetParent(blocks[pos].transform);
                    item.transform.position = blocks[pos].transform.position;
                }
            }
        }
        GameManager.player_pos = player.transform.localPosition;
    }
}
