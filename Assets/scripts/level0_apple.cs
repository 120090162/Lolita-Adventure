using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level0_apple : MonoBehaviour
{
    public Vector3 ApplePositon;
    public GameObject lightApparent;
    private AudioSource GetSound;
    
    void Start()
    {
        ApplePositon = transform.position;
        GetSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D()
    {
        GameManager.collect_counts++;
        AudioSource.PlayClipAtPoint(GetSound.clip, transform.position);
        Destroy(gameObject);
        lightApparent.SetActive(true);
        // Debug.Log("Apple is eaten");
    }
}
