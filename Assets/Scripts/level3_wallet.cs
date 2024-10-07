using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3_wallet : MonoBehaviour
{
    
    public Vector3 WalletPositon;
    private AudioSource GetSound;
    void Start()
    {
        WalletPositon = transform.position;
        GetSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D()
    {
        GameManager.collect_counts++;
        AudioSource.PlayClipAtPoint(GetSound.clip, transform.position);
        Destroy(gameObject);
    }
}

