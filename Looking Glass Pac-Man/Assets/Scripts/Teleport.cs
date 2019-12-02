using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform target;
    public bool justUsed;

    void Start()
    {
        justUsed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!justUsed)
        {
            target.GetComponent<Teleport>().justUsed = true;
            other.transform.position = target.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        justUsed = false;
    }
}
