using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChange : MonoBehaviour
{
    public List<GameObject> items;
    public List<GameObject> blocks;
    public void ChangePuzzle()
    {
        foreach (var item in items)
        {
            int pos = GameManager.picture.IndexOf(item.GetComponent<ItemPos>().id);
            if (pos != -1)
            {
                item.transform.SetParent(blocks[pos].transform);
                item.transform.position = blocks[pos].transform.position;
            }
        }
    }
}
