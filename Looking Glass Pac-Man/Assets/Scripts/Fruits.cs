﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    VariableManager vm;
    public int scoreValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vm.AddScore(scoreValue);
            vm.moveMode = PathFinderAI.MoveMode.FREIGHTENED;
            Destroy(transform.gameObject);
        }
    }
}
