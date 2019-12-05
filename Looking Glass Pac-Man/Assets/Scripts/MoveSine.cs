using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSine : MonoBehaviour
{
    private float newY;
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    public bool active = false;

    private Vector3 newPosition;
    public Vector3 origin;

    void Awake()
    {
        origin = transform.position;
    }

    void Update()
    {
        if (active)
        {
            newY = origin.y + amplitude * Mathf.Sin(Time.time * frequency);
            newPosition = transform.position;
            newPosition.y = newY;
            transform.position = newPosition;
        } else 
        {
            transform.position = origin;
        }
    }
}
