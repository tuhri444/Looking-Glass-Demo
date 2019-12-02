using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddCube : MonoBehaviour
{


    public void createCube(Vector3 pLocation, Quaternion pRotation, GameObject prefab)
    {
        GameObject newPipe = Instantiate(prefab, new Vector3(0,0,0), pRotation);
        newPipe.transform.parent = FindObjectOfType<TurnPipes>().transform;
        newPipe.transform.position = pLocation;
    }
}
