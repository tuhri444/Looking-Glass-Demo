using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 targetVector;
    private Vector3 destination;
    private bool destinationReached;

    [SerializeField,Range(0f,10f)]
    private float speed = 10;

    [SerializeField] private TurnPipes level;

    void Update()
    {
        FindObjectOfType<VariableManager>().speed = speed;
        FindObjectOfType<VariableManager>().playerPos = transform.position;
        Ray rayCheck = new Ray(transform.position, Vector3.zero); //Direction undetermined
        RaycastHit hit;

        //Determine direction
        if (Input.GetKeyDown(KeyCode.A))
        {
            rayCheck.direction = Vector3.left;
            if (Physics.Raycast(rayCheck, out hit, 1f))
                transform.rotation = Quaternion.Euler(Vector3.down * 90);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rayCheck.direction = Vector3.right;
            if (Physics.Raycast(rayCheck, out hit, 1f))
                transform.rotation = Quaternion.Euler(Vector3.up * 90);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rayCheck.direction = Vector3.up;
            if (Physics.Raycast(rayCheck, out hit, 1f))
                transform.rotation = Quaternion.Euler(Vector3.left * 90);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rayCheck.direction = Vector3.down;
            if (Physics.Raycast(rayCheck, out hit, 1f))
                transform.rotation = Quaternion.Euler(Vector3.right * 90);
        }

        Debug.DrawRay(rayCheck.origin, rayCheck.direction, Color.magenta);
        Debug.DrawRay(transform.position, transform.forward/* * 0.75f*/, Color.blue);

        if (!level.turning)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, 1f))
            {
                destination = hit.transform.position;
            }
            destinationReached = Vector3.Distance(destination, transform.position) < 0.0001f;
        }
        else
        {
            destination = transform.position;
        }

        

        if (destinationReached == false)
        {
            if(!level.turning)
                transform.position = Vector3.MoveTowards(transform.position,destination,Time.deltaTime*speed);
            
        }

    }
}
