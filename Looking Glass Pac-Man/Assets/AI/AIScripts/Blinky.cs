using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour
{
    PathFinderAI p;
    VariableManager vm;
    GameManager gm;

    float timer =0;
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
            if (mode == 0)
            {
                if (Time.time > timer && currentMode == MoveMode.SCATTER)
                {
                    timer = Time.time + chaseTime;
                    currentMode = MoveMode.CHASE;
                    Debug.Log("Chasing");
                }
                else if (Time.time > timer && currentMode == MoveMode.CHASE)
                {
                    timer = Time.time + scatterTime;
                    currentMode = MoveMode.SCATTER;
                    Debug.Log("Scattering");
                    mode++;
                }
            } else if(mode == 1)
            {
                if (Time.time > timer && currentMode == MoveMode.SCATTER)
                {
                    timer = Time.time + chaseTime;
                    currentMode = MoveMode.CHASE;
                    Debug.Log("Chasing");
                }
                else if (Time.time > timer && currentMode == MoveMode.CHASE)
                {
                    scatterTime = 5;
                    timer = Time.time + scatterTime;
                    currentMode = MoveMode.SCATTER;
                    Debug.Log("Scattering");
                    mode++;
                }
            }
            else if (mode == 2)
            {
                if (Time.time > timer && currentMode == MoveMode.SCATTER)
                {
                    timer = Time.time + chaseTime;
                    currentMode = MoveMode.CHASE;
                    Debug.Log("Chasing");
                }
                else if (Time.time > timer && currentMode == MoveMode.CHASE)
                {
                    timer = Time.time + scatterTime;
                    currentMode = MoveMode.SCATTER;
                    Debug.Log("Scattering");
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
                    Debug.Log("Chasing");
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
                p.target = vm.playerPos;
                break;
            case MoveMode.SCATTER:
                p.target = new Vector3(0.281f, 0.4297617f, 0.301f);
                break;
            case MoveMode.FREIGHTENED:
                p.target = gm.nodes[Random.Range(0, gm.nodes.Count - 1)].Position;
                break;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (!vm.gotHit)
        {
            other.GetComponent<SphereCollider>().enabled = false;
            vm.Damage(1);
        }
    }
}
