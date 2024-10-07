using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3_wallet : MonoBehaviour
{
    
    public Vector3 WalletPositon;
    
    void Start()
    {
        WalletPositon = transform.position;
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}

