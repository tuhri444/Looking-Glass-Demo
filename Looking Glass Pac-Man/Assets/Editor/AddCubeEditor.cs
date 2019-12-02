using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AddCube))]
public class AddCubeEditor : Editor
{

    void OnSceneGUI()
    {
        AddCube cubeAddition = (AddCube)target;
        prefabs prefabs = FindObjectOfType<prefabs>();
        if (prefabs != null)
        {
            GameObject prefab = prefabs.PipePrefab;
            BoxCollider collider = prefab.GetComponent<BoxCollider>();
            Event e = Event.current;
            if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Space)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Vector3 normal = hit.normal;
                    Vector3 newLocation = normal * collider.size.x;
                    newLocation += hit.transform.position;
                    cubeAddition.createCube(newLocation, Quaternion.identity, prefabs.PipePrefab);
                }
            }
            else if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Q)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Vector3 normal = hit.normal;
                    Vector3 newLocation = normal * collider.size.x;
                    newLocation += hit.transform.position;
                    cubeAddition.createCube(newLocation, Quaternion.identity, prefabs.teleportPrefab);
                }
            }
        }
    }




}
