using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] public List<GameObject> modelTypes;
    private List<Pipe> Neighbours;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int amountOfNeighbours()
    {
        return Neighbours.Count;
    }

    public void ReloadModel()
    {
        changeModel();
        changeOrientation();
    }

    private void changeModel()
    {
        MeshFilter myMesh = GetComponent<MeshFilter>();
        MeshFilter newMesh;
        switch (Neighbours.Count)
        {
            case (2):

                break;
            case (3):

                break;
            case (4):

                break;
            case (5):
                newMesh = modelTypes[1].GetComponent<MeshFilter>();
                myMesh.mesh = newMesh.mesh;
                break;
            case (6):
                newMesh = modelTypes[0].GetComponent<MeshFilter>();
                myMesh.mesh = newMesh.mesh;
                break;
        }
    }

    private void changeOrientation()
    {

    }

    //private bool check4Sides()
    //{
    //    int amountOfStraights = 0;
    //    foreach (Pipe neighbour in Neighbours)
    //    {
    //        foreach (Pipe otherNeighbour in Neighbours)
    //        {
    //            if (neighbour != otherNeighbour)
    //            {

    //            }
    //        }
    //    }



    //}
}
