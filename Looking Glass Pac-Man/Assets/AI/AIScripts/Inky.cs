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
    [SerializeField] private float animationSpeed;
    private int index;
    private float timePassed;
    private float totalTimePassed;
    bool started = false;
    public PathFinderAI.MoveMode currentMode;
    // Start is called before the first frame update
    void Start()
    { 
        p = GetComponent<PathFinderAI>();
        vm = FindObjectOfType<VariableManager>();
        pm = FindObjectOfType<PlayerMovement>();
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
            if (totalTimePassed > 5)
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
                p.target = ((vm.playerPos + (Vector3.Normalize(pm.transform.rotation.eulerAngles)*2)) - FindObjectOfType<Blinky>().transform.position)*2;
                break;
            case PathFinderAI.MoveMode.SCATTER:
                p.target = new Vector3(-0.277f, 0.4297617f, 0.283f);
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
