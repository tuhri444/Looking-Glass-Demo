using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour
{
    PathFinderAI p;
    VariableManager vm;
    bool start = false;
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
        vm =FindObjectOfType<VariableManager>();
        currentMode = MoveMode.CHASE;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha6))
        {
            start = true;
        }
        if(currentMode == MoveMode.STOP)
        {
            p.target = p.currentPos;
        }
        if (currentMode == MoveMode.CHASE && start)
        {
            p.target = vm.playerPos;
        }
        if(currentMode == MoveMode.SCATTER)
        {
            p.target = new Vector3(-0.429f,0.429f,0.429f);
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            currentMode = MoveMode.CHASE;
            start = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            currentMode = MoveMode.SCATTER;
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            currentMode = MoveMode.STOP;
        }
    }
}
