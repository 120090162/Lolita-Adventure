using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Souvenir Collection: " + GameManager.collect_counts + "\n" + "Total Steps: " + GameManager.count + "\n" + "Number of restoring picture(puzzle): " + GameManager.score;
    }
}
