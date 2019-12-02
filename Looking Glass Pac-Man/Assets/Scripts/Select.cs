using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private GameObject StartItem;
    [SerializeField] private GameObject ExitItem;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private int menuItems;
    
    void Start()
    {
        menuItems = 1;
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("d-pad-y") > 0)
        {
            if (menuItems <= 0)
            {
                menuItems = 0;
            }
            else
            {
                menuItems--;
            }
            
        }
        else if (Input.GetAxis("d-pad-y") < 0)
        {
            if (menuItems >= 1)
            {
                menuItems = 1;
            }
            else
            {
                menuItems++;
            }
        }

        if (menuItems == 1)
        {
            transform.position = startPosition;
        }
        else transform.position = new Vector3(-9.32f, 1.6f, transform.position.z);
    }
}
