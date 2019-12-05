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

        void SpawnPrefab(GameObject prefab)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Vector3 normal = hit.normal;
                Vector3 newLocation = normal * prefab.GetComponent<MeshRenderer>().bounds.size.x;
                newLocation += hit.transform.position;
                if (Event.current.shift)
                    hit.transform.GetComponent<AddCube>().SwapCube(prefab);
                else
                    cubeAddition.createCube(newLocation, Quaternion.identity, prefab);
            }
        }



        if (prefabs != null)
        {
            List<GameObject> pipePrefabs = prefabs.PipePrefabs;
            Event e = Event.current;
            if (e.type == EventType.KeyDown)
            {
                switch (e.keyCode)
                {
                    case KeyCode.Alpha1:
                        SpawnPrefab(pipePrefabs[0]);
                        break;
                    case KeyCode.Alpha2:
                        SpawnPrefab(pipePrefabs[1]);
                        break;
                    case KeyCode.Alpha3:
                        SpawnPrefab(pipePrefabs[2]);
                        break;
                    case KeyCode.Alpha4:
                        SpawnPrefab(pipePrefabs[3]);
                        break;
                    case KeyCode.Alpha5:
                        SpawnPrefab(pipePrefabs[4]);
                        break;
                }
            }
        }


    }


}
