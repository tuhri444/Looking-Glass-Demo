using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddCube : MonoBehaviour
{
    private MeshRenderer mesh;
    private PlayerMovement playerScript;
    private Transform player;
    private prefabs prefabs;

    void Start()
    {
        prefabs = FindObjectOfType<prefabs>();
        mesh = GetComponent<MeshRenderer>();
        playerScript = FindObjectOfType<PlayerMovement>();
        player = playerScript.GetComponent<Transform>();
        GameObject pellet = Instantiate(prefabs.PelletPrefab, transform.position, Quaternion.identity);
        pellet.transform.parent = transform;
    }

    public void createCube(Vector3 pLocation, Quaternion pRotation, GameObject prefab)
    {
        GameObject newPipe = Instantiate(prefab, new Vector3(0,0,0), pRotation);
        newPipe.transform.parent = FindObjectOfType<TurnPipes>().transform;
        newPipe.transform.position = pLocation;
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
}
