using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4_star : MonoBehaviour
{
    public Vector3 StarPositon;
    private AudioSource GetSound;
    void Start()
    {
        StarPositon = transform.position;
        GetSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D()
    {
        GameManager.collect_counts++;
        AudioSource.PlayClipAtPoint(GetSound.clip, transform.position);
        Destroy(gameObject);
    }
}
