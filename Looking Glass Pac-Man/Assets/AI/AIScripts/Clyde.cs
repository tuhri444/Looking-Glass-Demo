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
    int mode = 0;
    [SerializeField] private float animationSpeed;
    private int index;
    private float timePassed;
    private float totalTimePassed;
    bool started = false;
    public PathFinderAI.MoveMode currentMode;

    void Start()
    {
        p = GetComponent<PathFinderAI>();
        vm = FindObjectOfType<VariableManager>();
        gm = FindObjectOfType<GameManager>();
        currentMode = PathFinderAI.MoveMode.SCATTER;
        timer = Time.time + scatterTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (vm.moveMode == PathFinderAI.MoveMode.FREIGHTENED)
        {
            currentMode = vm.moveMode;
        }
        if (currentMode == PathFinderAI.MoveMode.FREIGHTENED)
        {
            timePassed += Time.deltaTime;
            totalTimePassed += timePassed;
            if(totalTimePassed > 5)
            {
                currentMode = PathFinderAI.MoveMode.SCATTER;
            }
            if (timePassed >= animationSpeed)
            {
                if (index == 1) index = 0;
                else index++;
                timePassed = 0;
            }

            switch (index)
            {
                case 0:
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                    break;
                case 1:
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    break;
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        //currentMode = vm.moveMode;
        started = vm.startGhost;
        if (currentMode != PathFinderAI.MoveMode.FREIGHTENED)
        {
            {
                if (started)
                {
                    //Debug.Log("started");
                    if (mode == 0)
                    {
                        if (Time.time > timer && currentMode == PathFinderAI.MoveMode.SCATTER)
                        {
                            timer = Time.time + chaseTime;
                            currentMode = PathFinderAI.MoveMode.CHASE;
                            Debug.Log(gameObject.name + "Chasing");
                        }
                        else if (Time.time > timer && currentMode == PathFinderAI.MoveMode.CHASE)
                        {
                            timer = Time.time + scatterTime;
                            currentMode = PathFinderAI.MoveMode.SCATTER;
                            Debug.Log(gameObject.name + "Scattering");
                            mode++;
                        }
                    }
                    else if (mode == 1)
                    {
                        if (Time.time > timer && currentMode == PathFinderAI.MoveMode.SCATTER)
                        {
                            timer = Time.time + chaseTime;
                            currentMode = PathFinderAI.MoveMode.CHASE;
                            Debug.Log(gameObject.name + "Chasing");
                        }
                        else if (Time.time > timer && currentMode == PathFinderAI.MoveMode.CHASE)
                        {
                            scatterTime = 5;
                            timer = Time.time + scatterTime;
                            currentMode = PathFinderAI.MoveMode.SCATTER;
                            Debug.Log(gameObject.name + "Scattering");
                            mode++;
                        }
                    }
                    else if (mode == 2)
                    {
                        if (Time.time > timer && currentMode == PathFinderAI.MoveMode.SCATTER)
                        {
                            timer = Time.time + chaseTime;
                            currentMode = PathFinderAI.MoveMode.CHASE;
                            Debug.Log(gameObject.name + "Chasing");
                        }
                        else if (Time.time > timer && currentMode == PathFinderAI.MoveMode.CHASE)
                        {
                            timer = Time.time + scatterTime;
                            currentMode = PathFinderAI.MoveMode.SCATTER;
                            Debug.Log(gameObject.name + "Scattering");
                            mode++;
                        }
                    }
                    else if (mode == 2)
                    {
                        if (Time.time > timer && currentMode == PathFinderAI.MoveMode.SCATTER)
                        {
                            chaseTime = float.MaxValue;
                            timer = Time.time + chaseTime;
                            currentMode = PathFinderAI.MoveMode.CHASE;
                            Debug.Log(gameObject.name + "Chasing");
                        }
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            currentMode = PathFinderAI.MoveMode.STOP;
        }

        switch (currentMode)
        {
            case PathFinderAI.MoveMode.STOP:
                p.target = p.currentPos;
                break;
            case PathFinderAI.MoveMode.CHASE:
                toClose = Vector3.Distance(transform.localPosition, vm.playerPos)  < 8;
                if(toClose)
                {
                    currentMode = PathFinderAI.MoveMode.SCATTER;
                } else
                {
                    p.target = vm.playerPos;
                }
                break;
            case PathFinderAI.MoveMode.SCATTER:
                p.target = new Vector3(-0.291f, -0.4297618f, 0.285f);
                break;
            case PathFinderAI.MoveMode.FREIGHTENED:
                p.target = gm.nodes[Random.Range(0, gm.nodes.Count - 1)].Position;
                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (!vm.gotHit && other.name.Contains("Player") && currentMode != PathFinderAI.MoveMode.FREIGHTENED)
        {
            vm.gotHit = true;
            vm.health -= 1;
        }
    }
}
