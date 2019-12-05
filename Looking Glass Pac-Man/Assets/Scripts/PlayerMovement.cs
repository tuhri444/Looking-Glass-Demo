using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 targetVector;
    [SerializeField] private Vector3 destination;
    [SerializeField] public bool destinationReached;
    private bool left;
    private bool right;
    private bool up;
    private bool down;
    private AudioSource wakawaka;

    [SerializeField,Range(0f,10f)]
    private float speed = 10;

    private VariableManager vm;

    [SerializeField] private TurnPipes level;

    void Start()
    {
        vm = FindObjectOfType<VariableManager>();
        destination = transform.position;
        wakawaka = GetComponent<AudioSource>();
    }

    void Update()
    {
        vm.playerPos = transform.localPosition;
        vm.speed = speed;
        left = Input.GetAxis("Horizontal1") < 0 ? true : false;
        right = Input.GetAxis("Horizontal1") > 0 ? true : false;
        up = Input.GetAxis("Vertical1") < 0 ? true : false;
        down = Input.GetAxis("Vertical1") > 0 ? true : false;
        Ray rayCheck = new Ray(transform.position, Vector3.zero); //Direction undetermined
        RaycastHit hit;

        //Determine direction
        if (left)
        {
            rayCheck.direction = Vector3.left;
            if (Physics.Raycast(rayCheck, out hit, 1.2f))
                transform.rotation = Quaternion.Euler(Vector3.down * 90);
        }

        if (right)
        {
            rayCheck.direction = Vector3.right;
            if (Physics.Raycast(rayCheck, out hit, 1.2f))
                transform.rotation = Quaternion.Euler(Vector3.up * 90);
        }

        if (up)
        {
            rayCheck.direction = Vector3.up;
            if (Physics.Raycast(rayCheck, out hit, 1.2f))
                transform.rotation = Quaternion.Euler(Vector3.left * 90);
        }

        if (down)
        {
            rayCheck.direction = Vector3.down;
            if (Physics.Raycast(rayCheck, out hit, 1.2f))
                transform.rotation = Quaternion.Euler(Vector3.right * 90);
        }

        Debug.DrawRay(rayCheck.origin, rayCheck.direction, Color.magenta);
        Debug.DrawRay(transform.position, transform.forward/* * 0.75f*/, Color.blue);

        if (!level.turning)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, 1.2f))
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
            if (!level.turning)
            {
                wakawaka.Play();
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            }
            else wakawaka.Stop();

        }

    }
}
