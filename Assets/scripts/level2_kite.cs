using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_kite : MonoBehaviour
{
    public Vector3 KitePositon;
    private AudioSource GetSound;
    void Start()
    {
        KitePositon = transform.position;
        GetSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D()
    {
        GameManager.collect_counts++;
        AudioSource.PlayClipAtPoint(GetSound.clip, transform.position);
        Destroy(gameObject);
    }
}
