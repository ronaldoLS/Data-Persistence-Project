using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager Manager;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Manager == null)
        {
            Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
