using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
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

#if UNITY_EDITOR
    public void createCube(Vector3 pLocation, Quaternion pRotation, GameObject prefab)
    {
        GameObject newPipe = Instantiate(prefab, new Vector3(0,0,0), pRotation);
        Undo.RegisterCreatedObjectUndo(newPipe,"Created cube");
        newPipe.transform.parent = FindObjectOfType<TurnPipes>().transform;
        newPipe.transform.position = pLocation;
        Selection.activeGameObject = newPipe;
    }

    public void SwapCube(GameObject prefab)
    {
        GameObject newPipe = Instantiate(prefab, transform.position,Quaternion.identity);
        Undo.RegisterCreatedObjectUndo(newPipe,"Created cube");
        newPipe.transform.parent = FindObjectOfType<TurnPipes>().transform;
        Selection.activeGameObject = newPipe;
        Undo.DestroyObjectImmediate(gameObject);


    }
#endif

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
