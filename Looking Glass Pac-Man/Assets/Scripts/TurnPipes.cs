using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPipes : MonoBehaviour
{
    [Range(0.01f,10.00f)][SerializeField] private float turnSpeed;
    public bool turning = false;
    private Quaternion targetRotation;
    private Vector3 targetVector;
    public Vector3 Direction;
    public String Face;
    private bool left;
    private bool right;
    private bool up;
    private bool down;

    void Start()
    {
        targetRotation = new Quaternion();
    }


    void Update()
    {
        #region probablyuseless
        Debug.DrawRay(transform.position, transform.forward * 30, Color.blue);
        Debug.DrawRay(transform.position, -transform.forward * 30, Color.blue);
        Debug.DrawRay(transform.position, transform.right * 30, Color.red);
        Debug.DrawRay(transform.position, -transform.right * 30, Color.red);
        Debug.DrawRay(transform.position, transform.up * 30, Color.green);
        Debug.DrawRay(transform.position, -transform.up * 30, Color.green);

        Ray rayForward = new Ray(transform.position, transform.forward * 100);
        Ray rayBackward = new Ray(transform.position, -transform.forward * 100);
        Ray rayLeft = new Ray(transform.position, -transform.right * 100);
        Ray rayRight = new Ray(transform.position, transform.right * 100);
        Ray rayUp = new Ray(transform.position, transform.up * 100);
        Ray rayDown = new Ray(transform.position, -transform.up * 100);
        RaycastHit hit;
        
        if (Physics.Raycast(rayForward, out hit, 100f))
        {
            if (hit.collider.CompareTag("CameraWall"))
            {
                Direction = transform.InverseTransformDirection(transform.forward);
                Face = rayForward.ToString();
            }
        }
        if (Physics.Raycast(rayBackward, out hit, 100f))
        {
            if (hit.collider.CompareTag("CameraWall"))
            {
                Direction = transform.InverseTransformDirection(-transform.forward);
                Face = rayBackward.ToString();
            }
        }
        if (Physics.Raycast(rayLeft, out hit, 100f))
        {
            if (hit.collider.CompareTag("CameraWall"))
            {
                Direction = transform.InverseTransformDirection(-transform.right);
                Face = rayLeft.ToString();
            }
        }
        if (Physics.Raycast(rayRight, out hit, 100f))
        {
            if (hit.collider.CompareTag("CameraWall"))
            {
                Direction = transform.InverseTransformDirection(transform.right);
                Face = rayRight.ToString();
            }
        }
        if (Physics.Raycast(rayUp, out hit, 100f))
        {
            if (hit.collider.CompareTag("CameraWall"))
            {
                Direction = transform.InverseTransformDirection(transform.up);
                Face = rayUp.ToString();
            }
        }
        if (Physics.Raycast(rayDown, out hit, 100f))
        {
            if (hit.collider.CompareTag("CameraWall"))
            {
                Direction = transform.InverseTransformDirection(-transform.up);
                Face = rayDown.ToString();
            }
        }

        #endregion

        left = Input.GetAxis("Horizontal2") < 0 ? true : false;
        right = Input.GetAxis("Horizontal2") > 0 ? true : false;
        up = Input.GetAxis("Vertical2") < 0 ? true : false;
        down = Input.GetAxis("Vertical2") > 0 ? true : false;
        if (left && !turning)
        {
            targetVector = Vector3.up * -90;
            targetRotation = transform.rotation;
            targetRotation = Quaternion.Euler(targetVector) * targetRotation;
            turning = true;
        }
        if (right && !turning)
        {
            targetVector = (Vector3.up) * 90;
            targetRotation = transform.rotation;
            targetRotation = Quaternion.Euler(targetVector) * targetRotation;
            turning = true;
        }
        //if (up && !turning)
        //{
        //    targetVector = (Vector3.right) * 90;
        //    targetRotation = transform.rotation;
        //    targetRotation = Quaternion.Euler(targetVector) * targetRotation;
        //    turning = true;
        //}
        //if (down && !turning)
        //{
        //    targetVector = (Vector3.right) * -90;
        //    targetRotation = transform.rotation;
        //    targetRotation = Quaternion.Euler(targetVector) * targetRotation;
        //    turning = true;
        //}

        if (turning)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
            if (transform.rotation == targetRotation)
            {
                transform.rotation = targetRotation;
                turning = false;
            }
        }
    }

}

