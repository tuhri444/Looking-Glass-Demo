using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inky : MonoBehaviour
{
    PathFinderAI p;
    VariableManager vm;
    PlayerMovement pm;
    GameManager gm;
    GameObject g;

    float timer = 0;
    float scatterTime = 7;
    float chaseTime = 20;
    float mode = 0;
    bool started = false;

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
        timer = Time.time;
        p = GetComponent<PathFinderAI>();
        vm = FindObjectOfType<VariableManager>();
        pm = FindObjectOfType<PlayerMovement>();
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
                p.target = ((vm.playerPos + (Vector3.Normalize(pm.transform.rotation.eulerAngles)*2)) - FindObjectOfType<Blinky>().transform.position)*2;
                //g = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //g.transform.parent = transform.parent;
                //g.transform.localPosition = p.target;
                break;
            case MoveMode.SCATTER:
                p.target = new Vector3(-0.291f, -0.4297618f, 0.285f);
                break;
            case MoveMode.FREIGHTENED:
                p.target = gm.nodes[Random.Range(0, gm.nodes.Count - 1)].Position;
                break;
        }
    }
}
