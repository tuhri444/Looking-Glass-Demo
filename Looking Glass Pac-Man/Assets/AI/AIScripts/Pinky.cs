using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinky : MonoBehaviour
{
    PathFinderAI p;
    VariableManager vm;
    GameManager gm;
    PlayerMovement pm;

    float timer = 0;
    float scatterTime = 7;
    float chaseTime = 20;
    float mode = 0;
    bool started = false;

    public enum MoveMode
    {
        STOP,
        CHASE,
        SCATTER,
        FREIGHTENED
    }
    public MoveMode currentMode;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        p = GetComponent<PathFinderAI>();
        vm = FindObjectOfType<VariableManager>();
        gm = FindObjectOfType<GameManager>();
        pm = FindObjectOfType<PlayerMovement>();
        currentMode = MoveMode.SCATTER;
    }

    // Update is called once per frame
    void Update()
    {
        started = vm.startGhost;
        if (started)
        {
            if (mode == 0)
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
                p.target = pm.transform.forward*2;
                break;
            case MoveMode.SCATTER:
                p.target = new Vector3(-0.314f, 0.4297617f, -0.307f);
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
