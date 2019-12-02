using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{

    [Range(-10,100)][SerializeField] private int speed;
    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, speed, 0);
    }
}
