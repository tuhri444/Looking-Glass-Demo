using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, .5f)) return;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, Time.deltaTime * 10);
    }
}
