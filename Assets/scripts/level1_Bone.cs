using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class level1_Bone : MonoBehaviour
{
    public Vector3 BonePositon;
    private AudioSource GetSound;
    
    void Start()
    {
        BonePositon = transform.position;
        GetSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D() {
        GameManager.collect_counts++;
        AudioSource.PlayClipAtPoint(GetSound.clip, transform.position);
        Destroy(gameObject);
    }

}
