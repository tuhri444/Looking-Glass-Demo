using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Vector3 position;
<<<<<<< HEAD
    [SerializeField]List<Node> connectionsToNodes = new List<Node>();
=======
    [SerializeField]public List<Node> connectionsToNodes = new List<Node>();
>>>>>>> 95918d362b438326d0c9d702e7d0384254200e1a
    Node thisNode;
    [SerializeField] List<GameObject> connectionsToGameObjects = new List<GameObject>();
    public float f = 0;//total cost
    public float g = 0;//dist between current and start
    public float h = 0;//dist between this and end
    public GameObject pipe;
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
}

