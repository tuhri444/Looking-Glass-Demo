using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private prefabs pipeManager;
    private AudioSource deathSound;
    private prefabs prefabs;
    private MeshRenderer mesh;
    private PlayerMovement playerScript;
    private Transform player;

    void Start()
    {
        pipeManager = FindObjectOfType<prefabs>();
        if (pipeManager != null)
            deathSound = pipeManager.GetComponent<AudioSource>();
        else
            Debug.Log("pipemanager no there");
        prefabs = FindObjectOfType<prefabs>();
        mesh = GetComponent<MeshRenderer>();
        playerScript = FindObjectOfType<PlayerMovement>();
        player = playerScript.GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > prefabs.view)
        {
            mesh.enabled = false;
        }
        else
        {
            mesh.enabled = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if (pipeManager != null)
            //    deathSound.Play();
            Destroy(transform.gameObject);
        }
    }
}
