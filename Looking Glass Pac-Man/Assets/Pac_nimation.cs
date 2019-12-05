using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Pac_nimation : MonoBehaviour
{
    [SerializeField] private float animationSpeed;

    private PlayerMovement movementInfo;
    private bool moving;
    [SerializeField] private List<GameObject> animationStates;
    private int index;
    private float timePassed;

    void Start()
    {
        movementInfo = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= animationSpeed)
        {
            if (index == 2) index = 0;
            else index++;
            timePassed = 0;
        }

        switch (index)
        {
            case 0:
                animationStates[0].SetActive(true);
                animationStates[1].SetActive(false);
                animationStates[2].SetActive(false);
                break;
            case 1:
                animationStates[0].SetActive(false);
                animationStates[1].SetActive(true);
                animationStates[2].SetActive(false);
                break;
            case 2:
                animationStates[0].SetActive(false);
                animationStates[1].SetActive(false);
                animationStates[2].SetActive(true);
                break;
        }
    }
}
