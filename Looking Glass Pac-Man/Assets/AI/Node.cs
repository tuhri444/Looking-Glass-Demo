using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Vector3 position;
    [SerializeField]public List<Node> connectionsToNodes = new List<Node>();
    Node thisNode;
    [SerializeField] List<GameObject> connectionsToGameObjects = new List<GameObject>();
    public float f = 0;//total cost
    public float g = 0;//dist between current and start
    public float h = 0;//dist between this and end
    public GameObject pipe;
    [SerializeField]GameObject occupant;
    public Node() { }
    private void Start()
    {
        pipe = gameObject;
        position = pipe.transform.localPosition;
        thisNode = this;
    }
    public void add(Node n)
    {
        connectionsToNodes.Add(n);
        connectionsToGameObjects.Add(n.pipe);
    }
    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }
    public List<Node> connectionsList
    {
        get { return connectionsToNodes; }
    }
    public List<GameObject> connectionsListGO
    {
        get { return connectionsToGameObjects; }
    }
    public int connections
    {
        get { return connectionsToNodes.Count; }
    }
    public Node node
    {
        get { return thisNode; }
    }
    public GameObject Occupant
    {
        get { return occupant; }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<PathFinderAI>() != null)
        {
            //Debug.Log("Occupied");
            occupant = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<PathFinderAI>() != null)
        {
            //Debug.Log("Unoccupied");
            occupant = null;
        }
    }
}

