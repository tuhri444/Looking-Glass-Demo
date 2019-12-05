using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    [HideInInspector]
    public float speed = 10;
    [HideInInspector]
    public bool turning = false;
    [HideInInspector]
    public Quaternion targetRotation;
    [HideInInspector]
    public float turnSpeed = 10;
    [HideInInspector]
    public Vector3 playerPos;
    [HideInInspector]
    public bool startGhost = true;

}
