using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clyde : MonoBehaviour
{
    PathFinderAI p;
    VariableManager vm;
    GameManager gm;
    bool toClose = false;

    float timer = 0;
    float scatterTime = 7;
    float chaseTime = 20;
<<<<<<< HEAD
    float mode = 0;
=======
    int mode = 0;
>>>>>>> 95918d362b438326d0c9d702e7d0384254200e1a
    bool started = false;
    public enum MoveMode
    {
        STOP,
        CHASE,
        SCATTER,
        FREIGHTENED
    }
    public MoveMode currentMode;

    void Start()
    {
        currentMode = MoveMode.SCATTER;
        timer = Time.time;
        p = GetComponent<PathFinderAI>();
        vm = FindObjectOfType<VariableManager>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        started = vm.startGhost;
        if (started)
        {
<<<<<<< HEAD
            if (mode == 0)
            {
=======
            Debug.Log("started");
            if (mode == 0)
            {
                Debug.Log("mode 0");
>>>>>>> 95918d362b438326d0c9d702e7d0384254200e1a
                if (Time.time > timer && currentMode == MoveMode.SCATTER)
                {
                    timer = Time.time + chaseTime;
                    currentMode = MoveMode.CHASE;
<<<<<<< HEAD
=======
                    Debug.Log("KILL ME");
>>>>>>> 95918d362b438326d0c9d702e7d0384254200e1a
                }
                else if (Time.time > timer && currentMode == MoveMode.CHASE)
                {
                    timer = Time.time + scatterTime;
                    currentMode = MoveMode.SCATTER;
                    mode++;
                }
            }
            else if (mode == 1)
            {
                if (Time.time > timer && currentMode == MoveMode.SCATTER)
                {
                    timer = Time.time + chaseTime;
                    currentMode = MoveMode.CHASE;
                }
                else if (Time.time > timer && currentMode == MoveMode.CHASE)
                {
                    scatterTime = 5;
                    timer = Time.time + scatterTime;
                    currentMode = MoveMode.SCATTER;
                    mode++;
                }
            }
            else if (mode == 2)
            {
                if (Time.time > timer && currentMode == MoveMode.SCATTER)
                {
                    timer = Time.time + chaseTime;
                    currentMode = MoveMode.CHASE;
                }
                else if (Time.time > timer && currentMode == MoveMode.CHASE)
                {
                    timer = Time.time + scatterTime;
                    currentMode = MoveMode.SCATTER;
                    mode++;
                }
            }
            else if (mode == 2)
            {
                if (Time.time > timer && currentMode == MoveMode.SCATTER)
                {
                    chaseTime = float.MaxValue;
                    timer = Time.time + chaseTime;
                    currentMode = MoveMode.CHASE;
                }
            }
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
                toClose = Vector3.Distance(transform.position, vm.playerPos)  < 8;
                if(toClose)
                {
                    currentMode = MoveMode.SCATTER;
                } else
                {
                    p.target = vm.playerPos;
                }
                break;
            case MoveMode.SCATTER:
                p.target = new Vector3(0.281f, -0.444f, -0.287f);
                break;
            case MoveMode.FREIGHTENED:
                p.target = gm.nodes[Random.Range(0, gm.nodes.Count - 1)].Position;
                break;
        }
    }
    void OnTriggerEnter()
    {
        if (!vm.gotHit)
        {
            vm.gotHit = true;
            vm.health -= 1;
        }
    }
}
