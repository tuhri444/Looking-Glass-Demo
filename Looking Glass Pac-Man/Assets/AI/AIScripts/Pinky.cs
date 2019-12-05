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
    int mode = 0;
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
        gm = FindObjectOfType<GameManager>();
        pm = FindObjectOfType<PlayerMovement>();
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
                p.target = pm.transform.forward*2;
                break;
            case PathFinderAI.MoveMode.SCATTER:
                p.target = new Vector3(0.2824f, -0.4297617f, 0.29f);
                break;
            case PathFinderAI.MoveMode.FREIGHTENED:
                p.target = gm.nodes[Random.Range(0, gm.nodes.Count - 1)].Position;
                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (!vm.gotHit && other.name == "Player" && currentMode != PathFinderAI.MoveMode.FREIGHTENED)
        {

            vm.gotHit = true;
            vm.health -= 1;
        }
    }
}
