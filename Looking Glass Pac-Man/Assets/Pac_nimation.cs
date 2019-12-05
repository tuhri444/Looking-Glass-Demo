using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pac_nimation : MonoBehaviour
{
    [SerializeField] private float animationSpeed;

    private PlayerMovement movementInfo;
    private bool moving;
    [SerializeField] private List<GameObject> animationStates;
    private int index;
    private float timePassed;
    [SerializeField] private float dieSpeed;

    private VariableManager vm;
    private float currentHP;
    private TurnPipes gm;

    void Start()
    {
        vm = FindObjectOfType<VariableManager>();
        gm = FindObjectOfType<TurnPipes>();
        currentHP = vm.health;
        movementInfo = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (transform.localScale.magnitude <= 0.0001f && transform.localScale.magnitude >= -0.0001f)
        {
            gm.turning = true;
            vm.gotHit = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (vm.health < currentHP)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * dieSpeed);
            return;
        }
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
