using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSine : MonoBehaviour
{
    private float newY;
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;

    private Vector3 newPosition;
    private Vector3 origin;

    void Start()
    {
        origin = transform.position;
    }

    void Update()
    {
        newY = origin.y + amplitude * Mathf.Sin(Time.time * frequency);
        newPosition = transform.position;
        newPosition.y = newY;
        transform.position = newPosition;
    }
}
