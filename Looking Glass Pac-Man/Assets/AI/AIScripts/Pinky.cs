using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinky : MonoBehaviour
{
    PathFinderAI p;
    VariableManager vm;

    enum MoveMode
    {
        STOP,
        CHASE,
        SCATTER,
        FREIGHTENED
    }
    MoveMode currentMode;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<PathFinderAI>();
        vm = FindObjectOfType<VariableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            currentMode = MoveMode.CHASE;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            currentMode = MoveMode.SCATTER;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            currentMode = MoveMode.STOP;
        }

        switch (currentMode)
        {
            case MoveMode.STOP:
                p.target = p.currentPos;
                break;
            case MoveMode.CHASE:
                p.target = vm.playerPos;
                break;
            case MoveMode.SCATTER:
                p.target = new Vector3(0, 0, 0);
                break;
        }
    }
}
