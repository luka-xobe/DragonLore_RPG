using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Movement;

public class Block : MonoBehaviour
{
    [SerializeField] float blockingPossibility = 100f;
    Health health;
    // increment health by the amount blocking available

    public bool block = true;
  
    

    void Start()
    {
        health = GetComponent<Health>();
    }

   
    void Update()
    {
        
    }
}
